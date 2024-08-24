using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerMovement : MonoBehaviour {

        private Player _player;

        public void Configure(Player player) {

            _player = player;
        }

    }

}