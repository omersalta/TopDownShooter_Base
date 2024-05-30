using System.Collections.Generic;
using _Scripts.Items.Base;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public Dictionary<KeyCode, IInventoryItem> items = new();
        public IInventoryItem currentHandedItem;

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
            if (Input.GetKeyDown(KeyCode.Keypad1)) TakeHand(KeyCode.Keypad1);
            if (Input.GetKeyDown(KeyCode.Keypad2)) TakeHand(KeyCode.Keypad2);
            if (Input.GetKeyDown(KeyCode.Keypad3)) TakeHand(KeyCode.Keypad3);
            if (Input.GetKeyDown(KeyCode.Keypad4)) TakeHand(KeyCode.Keypad4);
            if (Input.GetKeyDown(KeyCode.Keypad5)) TakeHand(KeyCode.Keypad5);
        }

        private void TakeHand(KeyCode key)
        {
            if(currentHandedItem == items[key]) return;
            
            currentHandedItem.OnDownFromHand();
            currentHandedItem = items[key];
            currentHandedItem.OnTakeInHand();
        }

        public bool TryPickUp(IInventoryItem _newItem)
        {
            foreach (KeyValuePair<KeyCode, IInventoryItem> _item in items)
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