using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CardDisplay cardDisplay;
    private Vector3 originalScale;
    private bool isHolding = false;

    private void Awake()
    {
        originalScale = rectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        isHolding = true;
        rectTransform.localScale = originalScale * 1.5f;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        rectTransform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card Clicked");
        cardDisplay.FlipCard();
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (isHolding)
        {
            rectTransform.position = eventData.position;
        }
    }
}
