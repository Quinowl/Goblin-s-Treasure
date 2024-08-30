using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {


    public class PlayerMediator : Player {

        [SerializeField] private PlayerInputs _playerInputs;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerDamageable _playerDamageable;

        private void Awake() {

            _playerInputs.Configure(this);
        }

        public override void OnJumpInput() {
            throw new System.NotImplementedException();
        }
    }
}