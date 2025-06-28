using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI_CollectionManager;

public class ButtonCollectionManager : MonoBehaviour
{
    [SerializeField] private List<CollectionButtonConfig> collectionButtonConfigs = new();
    private UI_CollectionManager uI_CollectionManager;


    private void Start()
    {
        uI_CollectionManager = GetComponent<UI_CollectionManager>();
        CollectionButtonController();
    }

    #region Private

    private void CollectionButtonController()
    {
        foreach (var config in collectionButtonConfigs)
        {
            if (config.button != null)
            {
                config.button.onClick.AddListener(() => CollectionHandleAction(config.collection_ActionType));
            }
        }
    }

    private void CollectionHandleAction(Collection_ActionType collection_ActionType)
    {
        switch (collection_ActionType)
        {
            case Collection_ActionType.BackToShop:
                uI_CollectionManager.BackToShop();
                break;
            default:
                break;
        }
    }

    #endregion
}



[System.Serializable]
public class CollectionButtonConfig
{
    public Button button;
    public Collection_ActionType collection_ActionType;
}
