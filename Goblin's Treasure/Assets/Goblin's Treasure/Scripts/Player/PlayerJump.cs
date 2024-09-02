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
            _rigidbody2D.gravityScale = _player.CurrentStats.GravityScale;
        }

        public void TryJump() {

            // If the player isnt grounded, return
            if (!_player.IsGrounded()) return;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _player.CurrentStats.JumpForce);
        }

        public void CancelJump() {

            // If the player is grounded return because the player didnt jump
            if (_player.IsGrounded()) return;


            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y / _player.CurrentStats.JumpCancelDivisor);
        }
    }
}