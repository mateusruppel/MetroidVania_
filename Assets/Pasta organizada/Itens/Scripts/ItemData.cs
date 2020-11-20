using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptables/Item")]
public class ItemData : ScriptableObject
{
    [Space]
    [Header("General")]

    public ItemCategories.ItensTypes id;
    public Sprite spriteMain;

    public bool consumable;
    [Space]
    [Header("Events")]

    public UnityEvent UseHandler;
    public UnityEvent DeleteHandler;
}
