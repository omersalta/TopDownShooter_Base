using _Scripts.Items.InventoryItems;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class Weapon : CollactableBase
    {
        [SerializeField] private WeaponConfigScriptableObject _weaponConfig;
        
        public override void TryCollect(CollectorBase _collector)
        {
            PlayerCollector _playerCollector = _collector.GetComponent<PlayerCollector>();
            if(_playerCollector == null) return;
            
            if (_playerCollector.PlayerInventory.IsInventoryAvailable())
            {
                GameObject _weapondPrefab = Instantiate(_weaponConfig.weaponPrefab, _playerCollector.PlayerInventory.transform);
                _weapondPrefab.name = _weaponConfig.weaponName + " Clone";
                InventoryItems.Weapon weapon = _weapondPrefab.AddComponent<InventoryItems.Weapon>();
                weapon.Initialize(_weaponConfig,gameObject);
                _playerCollector.PlayerInventory.PickUp(weapon);
                
                OnCollect();
            }
        }

        public void OnCollectt()
        {
            throw new System.NotImplementedException();
        }
    }
}