using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UI_RandomManager;

public class RandomButton_Manager : MonoBehaviour
{
    [SerializeField] private List<RandomButtonConfig> RandomButtonConfigs = new();

    private UI_RandomManager ui_Random;

    private void Start()
    {
        ui_Random = GetComponent<UI_RandomManager>();
        RandomButtonController();
    }

    #region Private
    private void RandomButtonController()
    {
        foreach (var config in RandomButtonConfigs)
        {
            if (config.button != null)
            {
                config.button.onClick.AddListener(() => RandomHandleAction(config.random_ActionType));
            }
                
        }
    }

    private void RandomHandleAction(Random_ActionType random_ActionType)
    {
        switch (random_ActionType) 
        {
            case Random_ActionType.backToShop:
                ui_Random.BackToShop(); 
                break;
            default:
                break;
        }
    }
    #endregion
}



[System.Serializable]
public class RandomButtonConfig
{
    public Button button;
    public Random_ActionType random_ActionType;
}
