using UnityEngine;
using UnityEngine.InputSystem;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerInputs : MonoBehaviour {

        private Player _player;
        private PlayerInput _playerInput;

        public void Configure(Player player) {
        
            _player = player;
        }

        private void Awake() {

            _playerInput = GetComponent<PlayerInput>();


        }

    }

}