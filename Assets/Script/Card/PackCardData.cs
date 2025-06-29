using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MappingCard_Manager;

[CreateAssetMenu(fileName = "PackCard", menuName = "Shop/PackCard")]
public class PackCardData : ScriptableObject
{
    public Sprite coinImage;
    public Sprite itemImage;
    public string cardText;
    public int coinText;
    public CardPackType cardPackType;
}
