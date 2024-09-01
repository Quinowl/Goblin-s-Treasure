using UnityEngine;

namespace GoblinsTreasure.Scripts.Player {

    public abstract class Player : MonoBehaviour {

        public PlayerStats CurrentStats { get; protected set; }

        // ===== INPUTS =====
        public abstract void OnMoveInput(float value);
        public abstract void OnJumpInput();

        // ===== EVENTS =====
        public abstract void OnStatsUpdated();
        public abstract void ResetPlayer();
    }

}