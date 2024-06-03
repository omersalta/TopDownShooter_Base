using _Scripts.Player;
using _Scripts.Player.InventoryItems;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Items.CollectableItems
{
    public class CollectableWeapon : CollactableBase
    {
        [SerializeField] protected WeaponConfigScriptableObject weaponConfig;
        public override void TryCollect(CollectorBase collector)
        {
            PlayerCollector playerCollector = collector.GetComponent<PlayerCollector>();
            if(playerCollector == null) return;
            
            if (playerCollector.PlayerInventory.IsInventoryAvailable())
            {
                GameObject weapondPrefab = Instantiate(weaponConfig.PlayerWeaponPrefab, playerCollector.PlayerInventory.transform);
                weapondPrefab.name = weaponConfig.WeaponName + " Clone";
                //TODO multiple weapon creating ex. rocket launcher, knife, pistol
                WeaponBase weapon = weapondPrefab.GetComponent<WeaponBase>();
                if (weapon == null)
                {
                    Debug.Log("weapon not include base script");
                    return;
                }
                weapon.InitializeWeapon(weaponConfig);
                playerCollector.PlayerInventory.PickUpFromGround(weapon);
                
                OnCollect();
            }
            
        }
        
    }
}