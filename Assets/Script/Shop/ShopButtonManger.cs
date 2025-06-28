using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI_ShopManager;

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
            if (config.button != null)
            {
                config.button.onClick.AddListener(() => ShopHandleAction(config.shopActionType));
            }
                
        }
    }

    private void ShopHandleAction(Shop_ActionType shopActionType)
    {
        switch(shopActionType)
        {
            case Shop_ActionType.Collection:
                shopManager.Collection();
                break;
            case Shop_ActionType.Purchase:
                shopManager.Purchase(); 
                break;
            case Shop_ActionType.Confirm:
                shopManager.Confirm(); 
                break;
                case Shop_ActionType.Cancle: 
                shopManager.Cancle();
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
}
