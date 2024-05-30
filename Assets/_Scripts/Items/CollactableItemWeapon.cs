using _Scripts.Items.Base;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items
{
    public class CollactableItemWeapon : CollactableItemBase
    {
        [SerializeField] private WeaponConfigScriptableObject _weaponConfig;
        
        public override void TryCollect(ItemCollector itemCollector)
        {
            if (itemCollector.PlayerInventory.IsInventoryAvailable())
            {
                
                OnCollect();
            }
        }

        public override void OnCollect()
        {
            Debug.Log("Sub Class On Collect");
            base.OnCollect();
        }
    }
}