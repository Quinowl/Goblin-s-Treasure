using UnityEngine;

namespace GoblinsTreasure.Scripts.Gameplay {

    public class Crate : MonoBehaviour {

        [SerializeField] private Rigidbody2D _rigidbody2d;
        [SerializeField] private float _forceMultiplier = 5f;
        [SerializeField] private float _stopDrag = 5f;

        private bool _isPushed;
        private Vector2 _pushDirection;

        private void FixedUpdate() {
            if (_isPushed) _rigidbody2d.AddForce(_pushDirection * _forceMultiplier, ForceMode2D.Force);
            else _rigidbody2d.drag = _stopDrag;
        }

        public void Push(float force) {
            _rigidbody2d.drag = 0f;
            _isPushed = true;
            _pushDirection = new Vector2(force, 0f);
        }

        public void StopPush() => _isPushed = false;
    }
}