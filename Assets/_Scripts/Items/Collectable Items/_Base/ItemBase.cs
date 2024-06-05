using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Items.CollectableItems
{
    public abstract class ItemBase : MonoBehaviour
    {
        public ItemType ItemType;
        public string ItemName;
        //todo cursor description ext.
        
    }
    
    public enum ItemType 
    {
        Weapon,
        Booster,
        Attachment,
        UsableInventoryItem
    }
}
