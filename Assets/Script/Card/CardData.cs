using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardData", fileName ="card/CardData")]
public class CardData : ScriptableObject
{
    public string cardID;
    public Sprite cardFrontImage;
    public Sprite cardBackImage;
    public RarityType rarity; 

    public enum RarityType
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
}
