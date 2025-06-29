using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private TMP_Text number_text;
    [SerializeField] private Button left_Button;
    [SerializeField] private Button right_Button;

    private int minAmount = 1;
    private int maxAmount = 10;
    private int step = 1;
    private int currentAmount;

    private void Start()
    {
        AmountController();
    }

    #region private
    private void AmountController()
    {
        currentAmount = minAmount;
        UpdateNumber();

        left_Button.onClick.AddListener(OnLeftSide);
        right_Button.onClick.AddListener(OnRightSide);
    }

    private void OnLeftSide()
    {
        if (currentAmount - step <= maxAmount)
        {
            currentAmount -= step;
            UpdateNumber();
            Debug.Log(currentAmount);
        }
    }

    private void OnRightSide()
    {
        if (currentAmount + step <= maxAmount)
        {
            currentAmount += step;
            UpdateNumber();
        }
    }

    private void UpdateNumber()
    {
        number_text.text = currentAmount.ToString();
    }
    

    #endregion

}
