

using _Scripts.Inventory_Items;
using _Scripts.Player.InventoryItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Items.CollectableItems
{
    public class CollactableBandage : CollactableBase
    {
        [Range(1f,100f)]
        [SerializeField] private float _healthAmount;
        [SerializeField] private GameObject _inventoryPrefab;
        public override void TryCollect(CollectorBase collector)
        {
            
            //check if the collector has an inventory
            InventoryBase inventory = collector.Inventory.GetComponent<InventoryBase>();
            if (inventory == null) return;

            if (inventory.IsInventoryAvailableForNonUsable())
            {
                GameObject attachmentPrefab = Instantiate(_inventoryPrefab, inventory.transform);
                Bandage component = attachmentPrefab.GetComponent<Bandage>();
                if (component == null)
                {
                    Debug.Log("weapon not include base script");
                    return;
                }
                component.InitializeBandage(_healthAmount);
                inventory.PickUpSubItem(component);

                OnCollect();
            }
        }
    }
}