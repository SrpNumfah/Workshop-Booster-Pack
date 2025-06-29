using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI_ShopManager;
using static MappingCard_Manager;

public class ShopButtonManger : MonoBehaviour
{
    [SerializeField] private List<ShopButtonConfig> shopButtonConfigs = new();
    private UI_ShopManager shopManager;


    private void Start()
    {
        shopManager = GetComponent<UI_ShopManager>();
        ShopButtonController();
    }

    #region Private
    private void ShopButtonController()
    {
        foreach (var config in shopButtonConfigs)
        {
            var capturedConfig = config; 

            if (capturedConfig.button != null)
            {
                capturedConfig.button.onClick.AddListener(() =>
                    ShopHandleAction(capturedConfig.shopActionType, capturedConfig.cardPackType));
            }
        }
    }

    private void ShopHandleAction(Shop_ActionType shopActionType,CardPackType cardPackType = CardPackType.None)
    {
        switch(shopActionType)
        {
            case Shop_ActionType.Collection:
                shopManager.Collection();
                break;
            case Shop_ActionType.Purchase:
                shopManager.Purchase(cardPackType); 
                break;
            case Shop_ActionType.Confirm:
                shopManager.Confirm(); 
                break;
                case Shop_ActionType.Cancel: 
                shopManager.Cancel();
                break;
            default:
                break;
        }
    }
    #endregion
}

[System.Serializable]
public class ShopButtonConfig
{
    public Button button;
    public Shop_ActionType shopActionType;
    public CardPackType cardPackType;
}
