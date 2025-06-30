using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardData;

public class CardCollectionManager : MonoBehaviour
{
    public static CardCollectionManager Instance { get; private set; }

    private Dictionary<string, (CardData data, int count)> collection = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    #region Public
    public void AddCard(CardData card)
    {
        if (collection.ContainsKey(card.cardID))
        {
            collection[card.cardID] = (card, collection[card.cardID].count + 1);
        }
        else
        {
            collection[card.cardID] = (card, 1);
        }

        Debug.Log($"Added card: {card.rarity.ToString()} (x{collection[card.cardID].count})");
    }

    public Dictionary<string, (CardData data, int count)> GetCollection()
    {
        return collection;
    }

    public List<(CardData data, int count)> GetCardsByRarity(RarityType rarity)
    {
        List<(CardData, int)> filtered = new();

        foreach (var entry in collection.Values)
        {
            if (entry.data.rarity == rarity)
                filtered.Add(entry);
        }

        return filtered;
    }
    #endregion
}
