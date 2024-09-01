using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerGroundChecker : MonoBehaviour {

        [SerializeField] private AreaChecker _groundChecker;

        public bool IsGrounded => _groundChecker.IsOverlapping;
    }
}