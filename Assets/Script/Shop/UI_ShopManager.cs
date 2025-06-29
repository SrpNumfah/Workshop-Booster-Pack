using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MappingCard_Manager;

public class UI_ShopManager : MonoBehaviour
{
    [Header("Main_Shop")]
    [SerializeField] private GameObject collection_Panel;
    [SerializeField] private GameObject purchasePopup;
    [SerializeField] private List<PackCardData> packCardDatas;
    [SerializeField] private PopupManager popupManager;
    

    [Header("shop_popup")]
    [SerializeField] private GameObject shopRandomCard_Panel;

    private PackCardData currentSelectedPack;



    public enum Shop_ActionType
    {
        None,
        Collection,
        Purchase, 
        Confirm,
        Cancel
    }


    #region Private
    private void Openthis(GameObject target)
    {
        // ปิดทุกอัน
        collection_Panel.SetActive(false);
        purchasePopup.SetActive(false);
        shopRandomCard_Panel.SetActive(false);


        // ปิดเฉพาะอันที่ต้องการ
        if (target != null)
        {
            target.SetActive(true);
        }
    }
    #endregion

    #region Public

    public void Collection()
    {
        Openthis(collection_Panel);
    }

    public void Purchase(CardPackType type)
    {
        var foundData = packCardDatas.Find(p => p.cardPackType == type);
        if (foundData == null)
        {
            Debug.LogWarning("ไม่พบ PackCardData สำหรับ " + type);
            return;
        }

        currentSelectedPack = foundData;
        purchasePopup.SetActive(true);
    }

    public void Confirm() 
    {
        var amount = popupManager.SelectedAmount;
        var totalcost = currentSelectedPack.coinText * amount;

        if (CoinManager.instance.SpendCoin(totalcost))
        {
            Openthis(shopRandomCard_Panel);
            Debug.Log(amount);
        }
        else
        {
            Debug.Log("Not enough coin");
        }

    }

    public void Cancel()
    {
        popupManager.ResetToDefault();
        purchasePopup.SetActive(false);
        CoinManager.instance.GetNoticeText.text = " "; 
    }

    #endregion
}
