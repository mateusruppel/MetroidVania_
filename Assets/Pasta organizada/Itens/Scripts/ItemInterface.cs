using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ItemInterface : MonoBehaviour
{
    public ItemData item;
    public int itemAmount;
    protected ItemCategories.ItensTypes type;
    protected Sprite mainSprite;
    protected bool consumable;
    UnityEvent UseHandler;
    UnityEvent DeleteHandler;
    public Action deleteCallback = null;

    #region Gets
    public bool isConsumable() => consumable;
    public Sprite GetSprite() => mainSprite;
    public ItemCategories.ItensTypes getType() => type;
    #endregion
    
    public void UseHandlerAddListener(Action function) 
    {
        UseHandler.AddListener(() => function());
    }

    void Awake()
    {
        type = item.id;
        mainSprite = item.spriteMain;
        consumable = item.consumable;
        UseHandler = item.UseHandler;
        DeleteHandler = item.DeleteHandler;
    }

    public void UseItem(Func<bool> checkIfCanUseItem = null)
    {
        bool canUse = true;
        if(checkIfCanUseItem != null)
        {
            canUse = checkIfCanUseItem();
        }
        if (consumable && canUse)
        {
            if (itemAmount > 0)
            {
                itemAmount--;
                if (itemAmount == 0) DeleteItem(deleteCallback);
            }
        }
        UseHandler.Invoke();
    }

    public void DeleteItem(Action callback)
    {
        if (callback != null) callback();
        //implementar
    }
}
