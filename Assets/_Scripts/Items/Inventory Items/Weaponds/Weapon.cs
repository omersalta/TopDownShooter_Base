using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public class Weapon : WeaponBase
    {
        public void Initialize(WeaponConfigScriptableObject weaponConfig)
        {
            _weaponConfig = weaponConfig;
            _inventorySprite = _weaponConfig.inventorySprite;
        }
        
        public override void OnTakeInHand()
        {
            lastShootTime = Time.time + _weaponConfig.slightOfHandTime ;
            base.OnTakeInHand();
        }

        public override void RaycastAction(Collider target)
        {
            throw new System.NotImplementedException();
        }

        public override void Use()
        {
            lastShootTime = Time.time;
            //todo create bullets
        }
    }
}