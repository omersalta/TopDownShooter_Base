using _Scripts.Inventory_Items;
using _Scripts.Player;
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
            //check if the collector has an inventory
            InventoryBase inventory = collector.Inventory.GetComponent<InventoryBase>();
            if(inventory == null) return;
            
            if (inventory.IsInventoryAvailable())
            {
                GameObject weapondPrefab = Instantiate(weaponConfig.Prefabs.WeaponOnCharacterHand, inventory.transform);
                WeaponBase weapon = weapondPrefab.GetComponent<WeaponBase>();
                if (weapon == null)
                {
                    Debug.Log("weapon not include base script");
                    return;
                }
                weapon.InitializeWeapon(weaponConfig, gameObject);
                inventory.PickUpFromGround(weapon);
                
                OnCollect();
            }
        }
    }
}