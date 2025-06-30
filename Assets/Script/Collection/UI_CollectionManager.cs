using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CardData;

public class UI_CollectionManager : MonoBehaviour
{
    [SerializeField] private GameObject shop_Panel;
    [SerializeField] private GameObject collection_Panel;

    [SerializeField] private Transform cardLayout;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private TMP_Dropdown rarityFilterDropdown;

    public enum Collection_ActionType
    {
        None,
        BackToShop
    }

    private void Start()
    {
        rarityFilterDropdown.onValueChanged.RemoveAllListeners();
        rarityFilterDropdown.onValueChanged.AddListener(OnFilterChanged);
        ShowAllCards();
    }

    #region Private
    private void OpenThis(GameObject target)
    {
        shop_Panel.SetActive(false);
        if (target != null)
        {
            target.SetActive(true);
        }
    }

   

   

    private void ShowCardsByRarity(RarityType rarity)
    {
        ClearLayout();
        var cards = CardCollectionManager.Instance.GetCardsByRarity(rarity);
        Debug.Log($" Showing rarity: {rarity}, found: {cards.Count} cards");
        foreach (var entry in cards)
        {
            CreateCardUI(entry.data, entry.count);
        }
    }

    private void ClearLayout()
    {
        foreach (Transform child in cardLayout)
        {
            if (child.GetComponent<CardDisplay>() != null) // ลบเฉพาะการ์ด
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void CreateCardUI(CardData data, int count)
    {
        if (cardLayout == null)
        {
            Debug.LogError("cardLayout is NULL!");
            return;
        }

        GameObject cardObj = Instantiate(cardPrefab, cardLayout);
        Debug.Log($"Created card: {data.rarity.ToString()} x{count}");

        var cardDisplay = cardObj.GetComponent<CardDisplay>();
        cardDisplay.Setup(data);
        cardDisplay.FlipCard();

        cardDisplay.SetAmountText(count);
    }
    #endregion

    #region Public
    public void BackToShop()
    {
        collection_Panel.SetActive(false);
        OpenThis(shop_Panel);

    }

    public void OnFilterChanged(int index)
    {
        Debug.Log($"Dropdown changed to index: {index}");

        if (index == 0) // All
            ShowAllCards();
        else
            ShowCardsByRarity((RarityType)(index - 1)); // Offset by 1
    }

    public void ShowAllCards()
    {
        ClearLayout();
        var allCards = CardCollectionManager.Instance.GetCollection();

        Debug.Log($"All Collection Count: {allCards.Count}");

        foreach (var entry in CardCollectionManager.Instance.GetCollection().Values)
        {
            CreateCardUI(entry.data, entry.count);
        }

    }




    #endregion
}
