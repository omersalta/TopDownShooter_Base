using _Scripts.Items.InventoryItems;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class WeaponAttachment : CollactableBase
    {
        [SerializeField] private AttacmentConfigScriptableObject _attacmentConfig;
        
        public override void TryCollect(CollectorBase _collector)
        {
            PlayerCollector _playerCollector = _collector.GetComponent<PlayerCollector>();
            if(_playerCollector == null) return;
            
            WeaponBase holdedWeapon = _playerCollector.PlayerInventory.currentHoldedItem.GetComponent<WeaponBase>();
            
            if (holdedWeapon == null) return;
            if(!holdedWeapon.isAvailableForAttachment(_attacmentConfig.type)) return;
            
            holdedWeapon.AddAttachment(_attacmentConfig);
            OnCollect();
        }
    }
}