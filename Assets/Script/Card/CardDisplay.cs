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
    [SerializeField] private TMP_Text cardAmountText;

    private CardData cardData;
    private bool isFlipped = false;
    private bool canZoom = false;

    #region Public
    public void Setup(CardData data)
    {
        cardData = data;
        cardBack_Image.sprite = data.cardBackImage;

        gameObject.SetActive(true);
        cardFront_Image.gameObject.SetActive(false);
        cardBack_Image.gameObject.SetActive(true);

        cardNameText.text = "";
        isFlipped = false;
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void FlipCard()
    {

        if (isFlipped) return; // กันไม่ให้พลิกซ้ำ

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
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.3f);


            // เพิ่มในคอลเลกชัน
            CardCollectionManager.Instance.AddCard(cardData);
        });
    }

    public void SetAmountText(int count)
    {
        if (cardAmountText != null)
            cardAmountText.text = $"x{count}";
    }

    public CardData GetCardData() => cardData;
    public bool IsFlipped() => isFlipped;
    
    #endregion

}
