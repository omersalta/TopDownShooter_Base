using System;
using System.Collections.Generic;
using _Scripts.ShootMechanic.Health_System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Inventory_Items
{
    public abstract class InventoryBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> inventorySlots;
        protected MainInventoryItemBase currentHoldedItem;
        public MainInventoryItemBase GetCurrentHoldedItem() => currentHoldedItem;
        protected Dictionary<KeyCode, MainInventoryItemBase> items = new();
        
        public abstract bool IsInventoryAvailable();
        public abstract bool IsInventoryAvailableForNonUsable();
        protected Team _myTeam;
        
        public virtual void RemoveFromInventory(MainInventoryItemBase removeItem)
        {
            if(removeItem == null) return;
            KeyCode removeKey;
            removeKey = KeyCode.Backspace;
            foreach (KeyValuePair<KeyCode, MainInventoryItemBase> item in items)
            {
                if (item.Value == removeItem)
                {
                    removeKey = item.Key;
                    break;
                }
            }
            if (removeKey == KeyCode.Backspace)
            {
                Debug.Log("item cannot finded");
                return;
            }
            items[removeKey] = null;
        }

        public virtual bool PickUpFromGround(MainInventoryItemBase newItem)
        {
            foreach (KeyValuePair<KeyCode, MainInventoryItemBase> item in items)
            {
                if (item.Value == null)
                {
                    items[item.Key] = newItem;
                    newItem.transform.parent = inventorySlots[GetIndexOfSlot(item.Key)].transform;
                    TryTakeHand(item.Key);
                    return true;
                }
            }
            Debug.Log("The item could not picked up");
            return false;
        }
        
        protected virtual void TryTakeHand(KeyCode key)
        {
            if (currentHoldedItem != null)
            {
                if (currentHoldedItem == items[key])
                {
                    Debug.Log("there is no equipment or you already hold the equipment");
                    return;
                }
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

        private int GetIndexOfSlot(KeyCode key)
        {
            int i = 0;
            foreach (var pair in items)
            {
                if (pair.Key == key) return i;
                i++;
            }
            return -1;
        }
        
        public Team GetTeam()
        {
            return _myTeam;
        }
    }
}