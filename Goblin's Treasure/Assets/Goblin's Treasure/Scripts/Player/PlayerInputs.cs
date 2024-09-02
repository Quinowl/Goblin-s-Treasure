using UnityEngine;
using UnityEngine.InputSystem;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerInputs : MonoBehaviour {

        [SerializeField] private PlayerInput _playerInput;

        private Player _player;

        private InputAction _movementInput;
        private InputAction _jumpInput;

        public void Configure(Player player) {

            _player = player;
        }

        private void Awake() {

            if (!_playerInput) _playerInput = GetComponent<PlayerInput>();

            _movementInput = _playerInput.actions[Constants.INPUT_MOVE];
            _jumpInput = _playerInput.actions[Constants.INPUT_JUMP];

            _movementInput.started += OnMoveInput;
            _movementInput.canceled += OnMoveInputCanceled;
            _jumpInput.started += OnJumpInputStarted;
            _jumpInput.canceled += OnJumpInputCanceled;
        }

        private void OnDestroy() {

            _movementInput.started -= OnMoveInput;
            _movementInput.canceled -= OnMoveInputCanceled;
            _jumpInput.started -= OnJumpInputStarted;
            _jumpInput.canceled -= OnJumpInputCanceled;
        }

        private void OnMoveInput(InputAction.CallbackContext context) => _player.OnMoveInput(context.ReadValue<float>());
        private void OnMoveInputCanceled(InputAction.CallbackContext _) => _player.OnMoveInput(0f);
        private void OnJumpInputStarted(InputAction.CallbackContext _) => _player.OnJumpInput();
        private void OnJumpInputCanceled(InputAction.CallbackContext _) => _player.OnJumpCancelInput();
    }
}