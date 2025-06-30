using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RandomManager : MonoBehaviour
{
    [SerializeField] private GameObject shop_Panel;
    [SerializeField] private GameObject Random_Panel;

    [SerializeField] private GameObject back_Button;
    [SerializeField] private RandomManager randomManager;

    public enum Random_ActionType
    {
        None,
        backToShop
    }

    private void Start()
    {
        back_Button.SetActive(false);
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
    
    public GameObject GetBack_Button => back_Button;
    public void BackToShop()
    {
        randomManager.GetCardData.Clear();
        Random_Panel.SetActive(false);
        OpenThis(shop_Panel);
    }
    #endregion
}
