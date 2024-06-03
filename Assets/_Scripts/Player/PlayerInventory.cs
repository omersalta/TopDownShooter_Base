using System;
using System.Collections.Generic;
using _Scripts.Player.InventoryItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class PlayerInventory : InventoryBase
    {
        public MainInventoryItemBase CurrentHoldedItem;
        private Dictionary<KeyCode, MainInventoryItemBase> _items = new();
        private List<InventoryNonUsableItemBase> _subItems = new List<InventoryNonUsableItemBase>();

        private void Start()
        {
            FindObjectOfType<PlayerInput>().MouseDownEvent.AddListener(OnMouseDown);
            FindObjectOfType<PlayerInput>().MouseUpEvent.AddListener(OnMouseUp);
            FindObjectOfType<PlayerInput>().KeyCode.AddListener(TryTakeHand);
            
            foreach (KeyCode key in  PlayerInput.InventoryKeys)
            {
                _items.Add(key,null);
            }
        }
        
        private void TryTakeHand(KeyCode key)
        {
            if (CurrentHoldedItem == _items[key])
            {
                Debug.Log("there is no equipment or you already hold the equipment");
                return;
            }
            
            CurrentHoldedItem?.OnDownFromHand();
            CurrentHoldedItem = _items[key];
            CurrentHoldedItem?.OnTakeInHand();
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
            foreach (KeyValuePair<KeyCode, MainInventoryItemBase> item in _items)
            {
                if (item.Value == null)
                {
                    _items[item.Key] = newItem;
                    TryTakeHand(item.Key);
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
            CurrentHoldedItem?.MouseDown(this);
        }
        
        private void OnMouseUp()
        {
            CurrentHoldedItem?.MouseUp(this);
        }
    }
}