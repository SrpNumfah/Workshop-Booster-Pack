using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Image cardBack_Image;
    [SerializeField] private Image cardFront_Image;
    [SerializeField] private TMP_Text cardNameText;

    private CardData cardData;
    private bool isFlipped = false;

    #region Public
    public void Setup(CardData data)
    {
        cardData = data;
        cardBack_Image.sprite = data.cardBackImage;
        cardFront_Image.gameObject.SetActive(false); // ซ่อนหน้าการ์ดตอนเริ่ม
        cardBack_Image.gameObject.SetActive(true);   // โชว์หลังการ์ดตอนเริ่ม
        cardNameText.text = "";
        isFlipped = false;
        transform.localRotation = Quaternion.Euler(0, 0, 0); // คว่ำไว้
    }

    public void FlipCard()
    {
        if (isFlipped) return;
        isFlipped = true;

        // หมุนครึ่งแรก 0 → 90 องศา
        transform.DOLocalRotate(new Vector3(0, 90, 0), 0.3f).OnComplete(() =>
        {
            // เปลี่ยนรูปภาพหลังจากครึ่งรอบ
            cardBack_Image.gameObject.SetActive(false);
            cardFront_Image.gameObject.SetActive(true);
            cardFront_Image.sprite = cardData.cardFrontImage;
            cardNameText.text = cardData.rarity.ToString();

            // หมุนต่ออีกครึ่ง 90 → 180 องศา
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.3f);

            // เพิ่มในคอลเลกชัน
            CardCollectionManager.Instance.AddCard(cardData);
        });
    }

    public CardData GetCardData() => cardData;
    #endregion

}
