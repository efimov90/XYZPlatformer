using UnityEngine;

public class LayerCollisionCheck : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;

    private Collider2D _collider;

    public bool IsTouchingLayer { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        UpdateIsTouchingLayer();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        UpdateIsTouchingLayer();
    }

    private void UpdateIsTouchingLayer()
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_layerMask);
    }
}
