using UnityEngine;

public class PlayerStatsSO : ScriptableObject {

    [field: SerializeField] public PlayerStats Stats { get; private set; }

    private void OnValidate() {

        Stats.CalculateGravityFields();
    }
}

public struct PlayerStats {

    [Header("Stats")]
    public float Health;
    public float MoveSpeed;
    [HideInInspector] public float JumpForce;
    public float JumpHeight;
    public float TimeToApex;
    public float Gravity;
    public float GravityScale;

    public void CalculateGravityFields() {

        // Calculates gravity strength based of gravity formule
        Gravity = -(2 * JumpHeight) / Mathf.Pow(TimeToApex, 2);
        GravityScale = Gravity / Physics2D.gravity.y;
        JumpForce = Mathf.Abs(Gravity) * TimeToApex;
    }
}