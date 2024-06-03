using System;
using System.Collections.Generic;
using _Scripts.Player.InventoryItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class PlayerInventory : InventoryBase
    {
        public MainInventoryItemBase currentHoldedItem;
        private Dictionary<KeyCode, MainInventoryItemBase> _items = new();
        private List<InventoryNonUsableItemBase> _subItems = new List<InventoryNonUsableItemBase>();

        private void Start()
        {
            FindObjectOfType<PlayerInput>().mouseDownEvent.AddListener(OnMouseDown);
            FindObjectOfType<PlayerInput>().mouseUpEvent.AddListener(OnMouseUp);
            FindObjectOfType<PlayerInput>().keyCode.AddListener(TryTakeHand);
            
            foreach (KeyCode _key in  PlayerInput.inventoryKeys)
            {
                _items.Add(_key,null);
            }
        }
        
        private void TryTakeHand(KeyCode key)
        {
            if (currentHoldedItem == _items[key])
            {
                Debug.Log("there is no equipment or you already hold the equipment");
                return;
            }
            
            currentHoldedItem?.OnDownFromHand();
            currentHoldedItem = _items[key];
            currentHoldedItem?.OnTakeInHand();
        }
        
        public override bool IsInventoryAvailable()
        {
            return _items.ContainsValue(null);
        }

        public override bool IsInventoryAvailableForNonUsable()
        {
            return true;
        }

        public override bool PickUpFromGround(MainInventoryItemBase newItem)
        {
            foreach (KeyValuePair<KeyCode, MainInventoryItemBase> _item in _items)
            {
                if (_item.Value == null)
                {
                    _items[_item.Key] = newItem;
                    TryTakeHand(_item.Key);
                    return true;
                }
            }
            Debug.Log("The item could not picked up");
            return false;
        }

        public override bool PickUpSubItem(InventoryNonUsableItemBase newItem)
        {
            _subItems.Add(newItem);
            return true;
        }

        private void OnMouseDown()
        {
            currentHoldedItem?.MouseDown(this);
        }
        
        private void OnMouseUp()
        {
            currentHoldedItem?.MouseUp(this);
        }
    }
}