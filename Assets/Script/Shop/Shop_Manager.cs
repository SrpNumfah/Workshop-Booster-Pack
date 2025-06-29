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
    [SerializeField] private UI_ShopManager shopManager;

    private void Start()
    {
        UseDataPack();
      
    }

    #region Private

    #region MappinDatapack
    private void UseDataPack()
    {
        CheckUseData();
        CheckMappingButton();
    }

    private void CheckUseData()
    {
        foreach (var data in packCards)
        {
            MappingPackData(data.cardPackType);
        }
    }

    private void CheckMappingButton()
    {
        if (shopManager == null) return;
        foreach (var ui in mappingCardPackDatas)
        {
            ui.InitButton((cardPackType) => shopManager.Purchase(cardPackType));
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

    

    #endregion
}
