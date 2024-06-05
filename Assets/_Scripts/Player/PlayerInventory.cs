using System;
using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerInventory : InventoryBase
    {
        protected void Start()
        {
            FindObjectOfType<PlayerInput>().MouseDownEvent.AddListener(OnMouseDown);
            FindObjectOfType<PlayerInput>().MouseUpEvent.AddListener(OnMouseUp);
            FindObjectOfType<PlayerInput>().KeyCode.AddListener(TryTakeHand);
            foreach (KeyCode key in PlayerInput.InventoryKeys)
            {
                items.Add(key,null);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (currentHoldedItem != null)
                {
                    DropItem(currentHoldedItem);
                }
                
            }
        }
        public override bool IsInventoryAvailable()
        {
            return items.ContainsValue(null);
        }

        public override bool IsInventoryAvailableForNonUsable()
        {
            return true;
        }

        private void DropItem(MainInventoryItemBase dropable)
        {
            if(dropable == null) return;
            dropable.DropAndDestroy();
            RemoveFromInventory(dropable);
            if (currentHoldedItem == dropable) currentHoldedItem = null;
        }
        
        private void DropItem(KeyCode key)
        {
            if (currentHoldedItem == items[key]) currentHoldedItem = null;
            items[key]?.DropAndDestroy();
            items[key] = null;
        }

        public void DropAll()
        {
            foreach (KeyCode key in PlayerInput.InventoryKeys)
            {
                DropItem(key);
            }
        }
        
    }
}