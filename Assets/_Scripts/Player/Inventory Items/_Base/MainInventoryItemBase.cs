using System.Collections.Generic;
using System.Linq;
using _Scripts.Items.CollectableItems;
using Unity.VisualScripting;
using UnityEngine;


namespace _Scripts.Player.InventoryItems
{
    public abstract class MainInventoryItemBase : InventoryNonUsableItemBase
    {
        
        protected float reuseCooldownValueInSeconds;
        protected float lastUseTime;
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
            if (_isReadyClickToggle && lastUseTime + reuseCooldownValueInSeconds <= Time.time)
            {
                _isReadyClickToggle = !_isReadyClickToggle;
                Use(user);
            }
        }

        public virtual void MouseUp(InventoryBase user)
        {
            _isReadyClickToggle = true;
        }

        public virtual void Use(InventoryBase user)
        {
            lastUseTime = Time.time;
        }
    }
    
}