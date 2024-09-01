using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerJump : MonoBehaviour {

        [SerializeField] private Rigidbody2D _rigidbody2D;

        private Player _player;
        private float _jumpForce;

        public float JumpForce {
            get => _jumpForce;
            set => _jumpForce = value;
        }

        public void Configure(Player player) {

            _player = player;
        }

        private void Awake() {

            if (!_rigidbody2D) _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void TryJump() {

            Debug.Log($"Jump behaviour, grounded? {_player.IsGrounded()}");
        }
    }
}