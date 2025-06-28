using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CollectionManager : MonoBehaviour
{
    [SerializeField] private GameObject shop_Panel;
    [SerializeField] private GameObject collection_Panel;

    public enum Collection_ActionType
    {
        None,
        BackToShop
    }

    #region Private
    private void OpenThis(GameObject target)
    {
        shop_Panel.SetActive(false);
        if (target != null)
        {
            target.SetActive(true);
        }
    }
    #endregion

    #region Public
    public void BackToShop()
    {
        collection_Panel.SetActive(false);
        OpenThis(shop_Panel);
    }
    #endregion
}
