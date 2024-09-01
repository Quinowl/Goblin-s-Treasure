using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerMovement : MonoBehaviour {

        [SerializeField] private Rigidbody2D _rigidbody2D;

        private Player _player;
        private float _moveDir;
        private float _moveSpeed;

        private bool _canMove = true;

        public float MoveDir {
            get => _moveDir;
            set => _moveDir = value;
        }

        public float MoveSpeed {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }

        public void Configure(Player player) {

            _player = player;
        }

        private void Awake() {

            if (!_rigidbody2D) _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {

            if (_canMove) Move();
        }

        public void Reset() => EnableMovement(true);

        private void Move() {

            // We multiply moveSpeed by 10 so that we can put smaller and more manipulable values in the inspector.
            _rigidbody2D.velocity = new Vector2(_moveSpeed * 10f * Time.fixedDeltaTime * _moveDir, _rigidbody2D.velocity.y);
        }

        public void EnableMovement(bool value) => _canMove = value;
    }
}