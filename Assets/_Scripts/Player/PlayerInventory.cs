using System.Collections.Generic;
using _Scripts.Items.Base;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public Dictionary<KeyCode, InventoryItemBase> items = new();
        public InventoryItemBase currentHandedItem;

        private void Start()
        {
            items.Add(KeyCode.Keypad1,null);
            items.Add(KeyCode.Keypad2,null);
            items.Add(KeyCode.Keypad3,null);
            items.Add(KeyCode.Keypad4,null);
            items.Add(KeyCode.Keypad5,null);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1)) TryTakeHand(KeyCode.Keypad1);
            else if (Input.GetKeyDown(KeyCode.Keypad2)) TryTakeHand(KeyCode.Keypad2);
            else if (Input.GetKeyDown(KeyCode.Keypad3)) TryTakeHand(KeyCode.Keypad3);
            else if (Input.GetKeyDown(KeyCode.Keypad4)) TryTakeHand(KeyCode.Keypad4);
            else if (Input.GetKeyDown(KeyCode.Keypad5)) TryTakeHand(KeyCode.Keypad5);
        }

        private void TryTakeHand(KeyCode key)
        {
            if (currentHandedItem == items[key])
            {
                Debug.Log("you hold equipment already");
                return;
            }
            
            currentHandedItem?.OnDownFromHand();
            currentHandedItem?.gameObject.SetActive(false);
            currentHandedItem = items[key];
            currentHandedItem.gameObject.SetActive(true);
            currentHandedItem.OnTakeInHand();
        }
        
        public bool IsInventoryAvailable ()
        {
            return PickUp(null);
        }

        public bool PickUp(InventoryItemBase _newItem)
        {
            foreach (KeyValuePair<KeyCode, InventoryItemBase> _item in items)
            {
                if (_item.Value == null)
                {
                    items[_item.Key] = _newItem;
                    return true;
                }
            }

            return false;
        }
    }
}