using System.Collections.Generic;
using System.Linq;
using _Scripts.Items.CollectableItems;
using Unity.VisualScripting;
using UnityEngine;


namespace _Scripts.Inventory_Items
{
    public abstract class MainInventoryItemBase : InventoryNonUsableItemBase
    {
        private List<InventoryNonUsableItemBase> _mySubItems = new List<InventoryNonUsableItemBase>();
        protected float reuseCooldownValueInSeconds;
        protected float lastUseTime;
        private bool _isReadyClickToggle = true;

        public void AddSubItem(InventoryNonUsableItemBase subItem)
        {
            _mySubItems.Add(subItem);
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

        public override void DropAndDestroy()
        {
            //FindObjectOfType<UIManager>().Set(null);
            if (_mySubItems.Count > 0)
            {
                foreach (var item in _mySubItems)
                {
                    item?.DropAndDestroy();
                }
            }
            base.DropAndDestroy();
            
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