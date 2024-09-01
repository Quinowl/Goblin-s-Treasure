using UnityEngine;
using UnityEngine.InputSystem;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerInputs : MonoBehaviour {

        [SerializeField] private PlayerInput _playerInput;

        private Player _player;

        public void Configure(Player player) {

            _player = player;
        }

        private void Awake() {

            if (!_playerInput) _playerInput = GetComponent<PlayerInput>();
        }

        private void OnMove(InputValue value) {

            _player.OnMoveInput(value.Get<float>());
        }

        private void OnJump(InputValue _) {

            _player.OnJumpInput();
        }
    }
}