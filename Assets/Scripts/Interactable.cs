using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Collider2D interactCollider;
    [SerializeField] private string layerName = "Interact";

    void Awake()
    {
        interactCollider.isTrigger = true;
        interactCollider.gameObject.layer = LayerMask.NameToLayer(layerName);
    }
}
