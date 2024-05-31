using _Scripts.Items.InventoryItems;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class WeaponAttachment : CollactableItemBase
    {
        [SerializeField] private AttacmentConfigScriptableObject _attacmentConfig;
        public override void TryCollect(PlayerItemCollector playerItemCollector)
        {
            WeaponBase holdedWeapon = playerItemCollector.PlayerInventory.currentHandedItem.GetComponent<WeaponBase>();
            
            if (holdedWeapon == null) return;
            if(!holdedWeapon.isAvailableForAttachment(_attacmentConfig.type)) return;
            
            holdedWeapon.AddAttachment(_attacmentConfig);
            OnCollect();
        }
    }
}