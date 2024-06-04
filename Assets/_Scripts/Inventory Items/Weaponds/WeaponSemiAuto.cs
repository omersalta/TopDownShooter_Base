using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class WeaponSemiAuto : WeaponBase
    {
        public override void Use(InventoryBase user)
        {
            Debug.Log("WeaponSemiAuto... USE");
            GameObject bullet = GetProjectileFromPool();
            bullet.GetComponent<ProjectileBase>().Setup(GetProjectileData());
            base.Use(user);
        }
        
        public override void OnPickUpFromGround()
        {
            //nothing
        }
        
    }
    
}