using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShopManager : MonoBehaviour
{
    [Header("Main_Shop")]
    [SerializeField] private GameObject collection_Panel;
    [SerializeField] private GameObject purchasePopup;

    [Header("shop_popup")]
    [SerializeField] private GameObject shopRandomCard_Panel;


    public enum Shop_ActionType
    {
        None,
        Collection,
        Purchase, 
        Confirm,
        Cancle

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

    public void Purchase()
    {
        purchasePopup.SetActive(true);
    }

    public void Confirm() 
    {
        Openthis(shopRandomCard_Panel);

    }

    public void Cancle()
    {
        purchasePopup.SetActive(false);
    }

    #endregion
}
