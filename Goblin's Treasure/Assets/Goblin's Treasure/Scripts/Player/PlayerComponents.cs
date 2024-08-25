using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public class PlayerComponents : MonoBehaviour {

        [field: SerializeField] public PlayerInputs PlayerInputController { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }

        public static PlayerComponents Instance { get; private set; }

        private void Awake() {

            if (!Instance) Instance = this;

            if (!PlayerInputController) PlayerInputController = GetComponent<PlayerInputs>();
            if (!Rigidbody) Rigidbody = GetComponent<Rigidbody2D>();
            if (!PlayerMovement) PlayerMovement = GetComponent<PlayerMovement>();
        }

    }
}