using _Scripts.Inventory_Items;
using UnityEngine;


namespace _Scripts.Items.CollectableItems
{
    public class CollectableAttachment : CollactableBase
    {
        [SerializeField] protected AttacmentConfigScriptableObject attacmentConfig;
        public override void TryCollect(CollectorBase collector)
        {
            //check if the collector has an inventory
            InventoryBase inventory = collector.Inventory.GetComponent<InventoryBase>();
            if(inventory == null) return;
            
            //check if the collector holding a weapon now
            WeaponBase weapon = collector.Inventory.GetCurrentHoldedItem()?.GetComponent<WeaponBase>();
            if(weapon == null) return;

            if (inventory.IsInventoryAvailableForNonUsable() && weapon.IsAvailableForAttachment(attacmentConfig.Type))
            {
                GameObject attachmentPrefab = Instantiate(attacmentConfig.Prefabs.AttachmentOnCharacterHand, inventory.GetCurrentHoldedItem().transform);
                AttachmentBase component = attachmentPrefab.GetComponent<AttachmentBase>();
                if (component == null)
                {
                    Debug.Log("weapon not include base script");
                    return;
                }
                inventory.GetCurrentHoldedItem().AddSubItem(component);
                component.InitializeAttachment(attacmentConfig,weapon,this.gameObject,attacmentConfig.InventorySprite);
                
                OnCollect();
            }
        }
    }
}