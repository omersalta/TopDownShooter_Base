using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Inventory_Items
{
    public abstract class InventoryBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> inventorySlots;
        protected MainInventoryItemBase currentHoldedItem;
        public MainInventoryItemBase CurrentHoldedItem => currentHoldedItem;
        protected Dictionary<KeyCode, MainInventoryItemBase> items = new();
        protected List<InventoryNonUsableItemBase> subItems = new List<InventoryNonUsableItemBase>();
        public abstract bool IsInventoryAvailable();
        public abstract bool IsInventoryAvailableForNonUsable();

        protected virtual void Start()
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                items.Add(KeyCode.Alpha1+i,null);
            }
        }

        public virtual bool PickUpFromGround(MainInventoryItemBase newItem)
        {
            foreach (KeyValuePair<KeyCode, MainInventoryItemBase> item in items)
            {
                if (item.Value == null)
                {
                    items[item.Key] = newItem;
                    TryTakeHand(item.Key);
                    return true;
                }
            }
            Debug.Log("The item could not picked up");
            return false;
        }

        public virtual bool PickUpSubItem(InventoryNonUsableItemBase newItem)
        {
            subItems.Add(newItem);
            return true;
        }
        
        protected virtual void TryTakeHand(KeyCode key)
        {
            if (currentHoldedItem == items[key])
            {
                Debug.Log("there is no equipment or you already hold the equipment");
                return;
            }
            
            currentHoldedItem?.OnDownFromHand();
            currentHoldedItem = items[key];
            currentHoldedItem?.OnTakeInHand();
        }
        
        protected void OnMouseDown()
        {
            currentHoldedItem?.MouseDown(this);
        }
        
        protected void OnMouseUp()
        {
            currentHoldedItem?.MouseUp(this);
        }
        
    }
}