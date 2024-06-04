using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class AttachmentBase : InventoryNonUsableItemBase
    {
        [SerializeField] public AttacmentConfigScriptableObject AttacmentConfig;

        public virtual void InitializeAttachment(AttacmentConfigScriptableObject attacmentConfig, WeaponBase weapon)
        {
            AttacmentConfig = Instantiate(attacmentConfig);
            weapon.AddAttachment(this);
        }
    }
    
}