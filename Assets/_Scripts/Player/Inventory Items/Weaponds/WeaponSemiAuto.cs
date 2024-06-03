using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class WeaponSemiAuto : WeaponBase
    {
        public override void Use(InventoryBase user)
        {
            Debug.Log("WeaponSemiAuto... USE");
            
            GameObject bullet = GetProjectileFromPool();
            bullet.transform.position = transform.position;
            // Calculate the direction
            Vector3 dir = GetAimPosition() - bullet.transform.position;
            // Make the transform look in the direction.
            bullet.transform.forward = dir;
            Debug.Log("bullet forward :" + bullet.transform.forward + ",  t f : "+ transform.forward);
            bullet.GetComponent<ProjectileBase>().Setup(bullet.transform.forward,2.5f);
            
            base.Use(user);
        }
        
        public override void OnPickUpFromGround()
        {
            //nothing
        }
        
    }
    
}