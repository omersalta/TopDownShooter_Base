using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class AttachmentBase : InventoryNonUsableItemBase
    {
        [SerializeField] public AttacmentConfigScriptableObject AttacmentConfig;

        public void InitializeAttachment(AttacmentConfigScriptableObject attacmentConfig, WeaponBase weapon,GameObject collectedReferance, Sprite inventorySprite)
        {
            dropSpawnGameObject = collectedReferance;
            this.inventorySprite = inventorySprite;
            AttacmentConfig = Instantiate(attacmentConfig);
            weapon.AddAttachment(this);
        }
    }
    
}