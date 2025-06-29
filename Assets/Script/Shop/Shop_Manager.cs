using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MappingCard_Manager;

public class Shop_Manager : MonoBehaviour
{
    [Header("Mapping_Data_List")]
    [SerializeField] private List<MappingCardPackData> mappingCardPackDatas;
    [SerializeField] private List<PackCardData> packCards;

    [Header("UI")]
    [SerializeField] private TMP_Text stackText;


    private void Start()
    {
        UseDataPack();
        StackCoin();
    }

    #region Private

    #region MappinDatapack
    private void UseDataPack()
    {
        UI_ShopManager uI_ShopManager = GetComponent<UI_ShopManager>();
        if (uI_ShopManager == null) return; 
        foreach (var data in packCards)
        {
            MappingPackData(data.cardPackType);
        }

        foreach (var ui in mappingCardPackDatas)
        {
            ui.InitButton((type) => uI_ShopManager.Purchase(type));
        }
    }

    private void MappingPackData(CardPackType cardPackType)
    {
        
        var ui = mappingCardPackDatas.Find(p => p.cardPackType == cardPackType);
        var data = packCards.Find(d => d.cardPackType == cardPackType);


        if (ui == null || data == null) return;

        ui.itemImage.sprite = data.itemImage;
        ui.coinImage.sprite = data.coinImage;
        ui.packCardHeader.text = data.cardText.ToString();
        ui.coinToUse.text = data.coinText.ToString();
    }

    #endregion

    #region Shop_UI
    private void StackCoin()
    {
        stackText.text = "X  $1000";
    }
    private void UpdateStackCoin()
    {

    }

    #endregion

    #endregion
}
