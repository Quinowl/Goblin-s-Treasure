using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerGroundChecker : MonoBehaviour {

        [SerializeField] private AreaChecker _groundChecker;

        //TODO: Debemos meter un script que sea el que aplique la gravedad. En el caso de que esté en el suelo - no aplica

        public bool IsGrounded => _groundChecker.IsOverlapping;
    }
}