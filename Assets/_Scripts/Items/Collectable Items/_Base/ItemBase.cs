using System;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public abstract class ItemBase : MonoBehaviour
    {
        protected ItemType _type;
        protected string _itemName;
        //todo cursor description ext.

        protected virtual void Initialize(ItemType type, string name)
        {
            _type = type;
            _itemName = name;
            
        }
        
    }
    
    public enum ItemType 
    {
        Weapon,
        Booster,
        HealthKit,
        Interactable,
        WeaponAttachment,
    }
}
