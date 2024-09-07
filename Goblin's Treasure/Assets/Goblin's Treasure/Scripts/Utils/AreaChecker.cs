using UnityEngine;

public class AreaChecker : MonoBehaviour {

    [Header("Configuration")]
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _size;
    [SerializeField] private LayerMask _layerCheck;

    [Header("Gizmos")]
    [SerializeField] private bool _drawGizmo;
    [SerializeField] private Color _gizmoColor;

    public Vector2 GetPosition => transform.position + (Vector3)_offset;
    public Vector2 GetSize => _size;

    public bool IsOverlapping => Check();

    private void OnDrawGizmos() {

        if (!_drawGizmo) return;
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireCube(transform.position + (Vector3)_offset, _size);
    }

    private bool Check() => Physics2D.OverlapBox(transform.position + (Vector3)_offset, _size, 0, _layerCheck);

    public bool GetComponentInCollider<T>(out T component) where T : Component {
        component = null;
        Collider2D collision = Physics2D.OverlapBox(GetPosition, _size, 0f, _layerCheck);
        if (collision != null && collision.TryGetComponent(out component)) return true;
        return false;
    }
}