using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Shop", menuName = "Shop/Item_Shop")]
public class Item_Shop : ScriptableObject
{
    public Image cardImage;
    public TMP_Text cardText;
    public TMP_Text coinText;
}
