using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField] private TMP_Text currentCoin_Text;
    [SerializeField] private TMP_Text notice_Text;
    [SerializeField] private int currentCoin;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    #region Private
    private void UpdateCoinUI()
    {
        if (currentCoin_Text == null) return;
        currentCoin_Text.text = "X"+ "" +currentCoin.ToString();

    }
    #endregion

    #region Public
    public int GetCoin => currentCoin;
    public TMP_Text GetNoticeText => notice_Text;
    public bool HasEnough(int amount) => currentCoin >= amount;

    public void Addcoin(int amount)
    {
        currentCoin += amount;
        UpdateCoinUI();
    }

    public bool SpendCoin(int amount)
    {
        if (currentCoin >= amount)
        {
            currentCoin -= amount;
            UpdateCoinUI();
            return true;
        }
        notice_Text.text = "Not Enough Coin!!";
        return false;
    }

    #endregion

}
