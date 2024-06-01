using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public class Weapon : WeaponBase
    {
        public override void OnTakeInHand()
        {
            lastShootTime = Time.time + _weaponConfig.slightOfHandTime ;
            base.OnTakeInHand();
        }

        public override void OnDropFromHand()
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