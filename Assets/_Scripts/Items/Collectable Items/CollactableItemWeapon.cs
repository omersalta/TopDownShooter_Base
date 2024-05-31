using _Scripts.Items.InventoryItems;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class CollactableItemWeapon : CollactableItemBase
    {
        [SerializeField] private WeaponConfigScriptableObject _weaponConfig;
        
        public override void TryCollect(PlayerItemCollector playerItemCollector)
        {
            if (playerItemCollector.PlayerInventory.IsInventoryAvailable())
            {
                GameObject _weapondPrefab = Instantiate(_weaponConfig.weaponPrefab, playerItemCollector.PlayerInventory.transform);
                _weapondPrefab.name = _weaponConfig.weaponName + " Clone";
                Weapon _weapon = _weapondPrefab.AddComponent<Weapon>();
                _weapon.Initialize(_weaponConfig);
                playerItemCollector.PlayerInventory.PickUp(_weapon);
                
                OnCollect();
            }
        }
        
    }
}