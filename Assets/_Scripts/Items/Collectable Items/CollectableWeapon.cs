using _Scripts.Player;
using _Scripts.Player.InventoryItems;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class CollectableWeapon : CollactableBase
    {
        [SerializeField] protected WeaponConfigScriptableObject _weaponConfig;
        public override void TryCollect(CollectorBase _collector)
        {
            PlayerCollector _playerCollector = _collector.GetComponent<PlayerCollector>();
            if(_playerCollector == null) return;
            
            if (_playerCollector.PlayerInventory.IsInventoryAvailable())
            {
                GameObject _weapondPrefab = Instantiate(_weaponConfig.playerWeaponPrefab, _playerCollector.PlayerInventory.transform);
                _weapondPrefab.name = _weaponConfig.weaponName + " Clone";
                //TODO multiple weapon creating ex. rocket launcher, knife, pistol
                WeaponBase _weapon = _weapondPrefab.GetComponent<WeaponBase>();
                if (_weapon == null)
                {
                    Debug.Log("weapon not include base script");
                    return;
                }
                _weapon.InitializeWeapon(_weaponConfig);
                _playerCollector.PlayerInventory.PickUpFromGround(_weapon);
                
                OnCollect();
            }
            
        }
        
    }
}