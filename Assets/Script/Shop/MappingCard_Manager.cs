using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MappingCard_Manager;

public class MappingCard_Manager : MonoBehaviour
{
    public enum CardPackType
    {
        None,
        Series1,
        Series2
    }
}

[System.Serializable]
public class MappingCardPackData
{
    public CardPackType cardPackType;
    public Image itemImage;
    public Image coinImage;
    public TMP_Text packCardHeader;
    public TMP_Text coinToUse;

    public Button purchaseButton;

    public void InitButton(System.Action<CardPackType> onClick)
    {
        if (purchaseButton == null) return;
        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(() => onClick(cardPackType));
        Debug.Log($"🎯 InitButton called for: {cardPackType}");
    }
}
