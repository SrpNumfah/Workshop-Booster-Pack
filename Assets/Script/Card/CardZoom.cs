using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CardDisplay cardDisplay;
    [SerializeField] private Image cardFront_Image;

    private Vector3 originalScale;
    private Vector3 originalPosition;
    private Transform originalParent;

    private GridLayoutGroup parentGrid;

    private bool isHolding = false;
    private float holdTime = 0f;
    private float holdThreshold = 0.3f;
    private bool isZoomed = false;

    private void Awake()
    {
        originalScale = rectTransform.localScale;
        Debug.Log("Original Scale: " + originalScale);
    }

    private void Update()
    {
        if (isHolding && cardDisplay.IsFlipped())
        {
            holdTime += Time.deltaTime;

            if (!isZoomed && holdTime > holdThreshold && cardDisplay.IsFlipped() && cardFront_Image.gameObject.activeSelf)
            {
                isZoomed = true;
                rectTransform.localScale = originalScale * 1.8f;

                //  บันทึกพาเรนต์ และตำแหน่ง
                originalParent = rectTransform.parent;
                originalPosition = rectTransform.position;

                //  ดึงและปิด GridLayoutGroup
                parentGrid = originalParent.GetComponent<GridLayoutGroup>();
                if (parentGrid != null)
                    parentGrid.enabled = false;

                //  ย้ายออกจาก layout
                rectTransform.SetParent(originalParent.parent, true); // ย้ายออกชั้นนึง
                rectTransform.SetAsLastSibling(); // อยู่บนสุด
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        holdTime = 0f;
        isZoomed = false;

        Debug.Log("Pointer Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isZoomed)
        {
            //  คืนขนาด
            rectTransform.localScale = originalScale;

            //  คืนพาเรนต์ + ตำแหน่งเดิม
            rectTransform.SetParent(originalParent);
            rectTransform.position = originalPosition;

            //  เปิด GridLayoutGroup กลับ
            if (parentGrid != null)
                parentGrid.enabled = true;
        }
        else
        {
            cardDisplay.FlipCard();
        }

        isHolding = false;
        isZoomed = false;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isZoomed)
        {
            rectTransform.position = eventData.position;
        }
    }
}