using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerGravityApplier : MonoBehaviour {

        [SerializeField] private Rigidbody2D _rigidbody2D;
        private Player _player;

        public void Configure(Player player) {
            _player = player;
        }

        public void TryToUpdateGravity(bool isGrounded) {
            float nextGravityValue = isGrounded ? 0f : _player.CurrentStats.GravityScale;
            if (isGrounded) {
                float yVelocity = _rigidbody2D.velocity.y <= 0f ? 0f : _rigidbody2D.velocity.y;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, yVelocity);
            }
            if (_rigidbody2D.gravityScale != nextGravityValue) _rigidbody2D.gravityScale = nextGravityValue;
        }
    }
}