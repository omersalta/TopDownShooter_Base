using System.Collections.Generic;
using System.Linq;
using _Scripts.Items.CollectableItems;
using Unity.VisualScripting;
using UnityEngine;


namespace _Scripts.Player.InventoryItems
{
    public abstract class MainInventoryItemBase : InventoryNonUsableItemBase
    {
        
        protected float reuseCooldownValueInAeconds;
        private bool _isReadyClickToggle = true;
        
        public void InitializeMainInventoryItem(List<InventorySubItemBaseData> subItemDatas, float cooldownSec, Sprite inventorySprite,
            GameObject dropSpawnPrefab, ItemType type, string name)
        {
            
        }
        
        public override void OnDownFromHand()
        {
            gameObject.SetActive(false);
        }

        public override void OnTakeInHand()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void MouseDown(InventoryBase user)
        {
            if (_isReadyClickToggle)
            {
                _isReadyClickToggle = !_isReadyClickToggle;
                Use(user);
            }
        }

        public virtual void MouseUp(InventoryBase user)
        {
            _isReadyClickToggle = true;
        }

        public abstract void Use(InventoryBase user);
    }
    
}