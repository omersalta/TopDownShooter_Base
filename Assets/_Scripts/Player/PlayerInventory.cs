using System.Collections.Generic;
using _Scripts.Items.InventoryItems;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public InventoryItemBase currentHoldedItem;
        public static readonly KeyCode[] _inventoryKeys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5};
        private Dictionary<KeyCode, InventoryItemBase> items = new();

        private void Start()
        {
            foreach (KeyCode _key in _inventoryKeys)
            {
                items.Add(_key,null);
            }
        }

        private void Update()
        {
            foreach (var VARIABLE in _inventoryKeys)
            {
                if(Input.GetKeyDown(VARIABLE)) TryTakeHand(VARIABLE);
            }
            
        }
        
        private void TryTakeHand(KeyCode key)
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
        
        public bool IsInventoryAvailable()
        {
            return items.ContainsValue(null);
        }

        public bool PickUp(InventoryItemBase newItem)
        {
            foreach (KeyValuePair<KeyCode, InventoryItemBase> _item in items)
            {
                if (_item.Value == null)
                {
                    items[_item.Key] = newItem;
                    currentHoldedItem = items[_item.Key];
                    currentHoldedItem.OnPickUpToHand();
                    
                    return true;
                }
            }
            Debug.Log("The item could not picked up");
            return false;
        }
    }
}