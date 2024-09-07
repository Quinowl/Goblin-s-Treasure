using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerMediator : Player {

        [SerializeField] private PlayerStatsSO _playerStatsData;

        [SerializeField] private PlayerInputs _playerInputs;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private PlayerGroundChecker _playerGroundChecker;
        [SerializeField] private PlayerPush _playerPush;
        [SerializeField] private PlayerGravityApplier _playerGravityApplier;
        [SerializeField] private PlayerDamageable _playerDamageable;

        private void Awake() {
            ResetStats();
            _playerInputs.Configure(this);
            _playerMovement.Configure(this);
            _playerJump.Configure(this);
            _playerPush.Configure(this);
            _playerGravityApplier.Configure(this);
        }

        private void Update() {
            _playerGravityApplier.TryToUpdateGravity(IsGrounded());
        }

        public override void ResetPlayer() {
            ResetStats();
            _playerMovement.Reset();
        }

        private void ResetStats() {
            CurrentStats = _playerStatsData.Stats;
            OnStatsUpdated();
        }

        public override void OnJumpInput() => _playerJump.TryJump();
        public override void OnJumpCancelInput() => _playerJump.CancelJump();

        public override void OnMoveInput(float value) {
            MovementDirection = value;
            _playerMovement.MoveDir = value;
        }

        public override void OnStatsUpdated() {
            _playerMovement.MoveSpeed = CurrentStats.MoveSpeed;
            _playerJump.JumpForce = CurrentStats.JumpForce;
        }

        public override bool IsGrounded() => _playerGroundChecker.IsGrounded;
    }
}