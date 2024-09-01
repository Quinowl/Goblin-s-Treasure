using UnityEngine;

public class AreaChecker : MonoBehaviour {

    [Header("Configuration")]
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _size;
    [SerializeField] private LayerMask _layerCheck;

    [Header("Gizmos")]
    [SerializeField] private bool _drawGizmo;
    [SerializeField] private Color _gizmoColor;

    public bool IsOverlapping => Check();

    private void OnDrawGizmos() {

        if (!_drawGizmo) return;
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireCube(transform.position + (Vector3)_offset, _size);
    }

    private bool Check() => Physics2D.OverlapBox(transform.position + (Vector3)_offset, _size, 0, _layerCheck);
}