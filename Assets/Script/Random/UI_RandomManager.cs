using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RandomManager : MonoBehaviour
{
    [SerializeField] private GameObject shop_Panel;
    [SerializeField] private GameObject Random_Panel;

    public enum Random_ActionType
    {
        None,
        backToShop
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
        Random_Panel.SetActive(false);
        OpenThis(shop_Panel);
    }
    #endregion
}
