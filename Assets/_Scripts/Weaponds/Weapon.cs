using UnityEngine;

namespace _Scripts.Weaponds
{
    public class Weapon : WeaponBase
    {
        
        public  Weapon(Sprite inventorySprite, WeaponConfigScriptableObject weaponConfig)
        {
            _weaponConfig = weaponConfig;
            _inventorySprite = inventorySprite;
        }
        
        public override void OnTakeInHand()
        {
            lastShootTime = Time.time + _weaponConfig.slightOfHandTime ;
            Debug.Log("You Take "+ _weaponConfig.weaponName +" to hand");
        }

        public override void OnDownFromHand()
        {
            Debug.Log("You Down "+ _weaponConfig.weaponName +" from hand");
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