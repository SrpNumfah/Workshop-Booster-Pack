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

        left_Button.onClick.AddListener(Decrease);
        right_Button.onClick.AddListener(Increase);
    }

    private void Decrease()
    {
        if (currentAmount - step >= minAmount)
        {
            currentAmount -= step;
            UpdateNumber();
        }
    }

    private void Increase()
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

    #region Public
    public int SelectedAmount => currentAmount;
    #endregion

}
