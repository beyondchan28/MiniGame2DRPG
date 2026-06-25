using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class NonCanvasButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent onClick = new UnityEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onClick?.Invoke();
        }
    }

    // Executes when the mouse hovers over the object
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.1f; // Visual hover effect
    }

    // Executes when the mouse leaves the object
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.1f; // Reset scale
    }
}
