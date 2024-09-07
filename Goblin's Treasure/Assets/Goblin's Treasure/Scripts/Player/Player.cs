using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public abstract class Player : MonoBehaviour {

        public PlayerStats CurrentStats { get; protected set; }

        // ===== PROPERTIES =====
        public float MovementDirection { get; protected set; }

        // ===== INPUTS =====
        public abstract void OnMoveInput(float value);
        public abstract void OnJumpInput();
        public abstract void OnJumpCancelInput();

        // ===== EVENTS =====
        public abstract void OnStatsUpdated();
        public abstract bool IsGrounded();
        public abstract void ResetPlayer();
    }

}