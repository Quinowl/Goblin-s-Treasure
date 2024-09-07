using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptables/Data/Player")]
public class PlayerStatsSO : ScriptableObject {

    [field: SerializeField] public PlayerStats Stats { get; private set; }

    private void OnValidate() {

        Stats.CalculateGravityFields();
    }
}

[System.Serializable]
public class PlayerStats {

    [Header("Stats")]
    public float Health;
    public float MoveSpeed;
    [HideInInspector] public float JumpForce;
    [Tooltip("Height in units to be reached in the jump"), SerializeField] private float JumpHeight;
    [Tooltip("Time it will take to reach the set height"), SerializeField] private float TimeToApex;
    [HideInInspector] public float GravityScale;
    public float JumpCancelDivisor;
    public float PushForce;

    /// <summary> This method calculates the gravity-related fields based on jump height and time to apex. </summary>
    public void CalculateGravityFields() {

        // Physics2D.gravity.y is typically a negative value, so we calculate a positive gravity force
        GravityScale = -(2 * JumpHeight) / (Mathf.Pow(TimeToApex, 2) * Physics2D.gravity.y);

        // JumpForce is the initial velocity required to reach the apex of the jump
        JumpForce = Mathf.Abs(Physics2D.gravity.y * GravityScale) * TimeToApex;
    }
}