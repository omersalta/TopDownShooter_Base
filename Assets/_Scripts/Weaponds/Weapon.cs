using _Scripts.Extensions;
using UnityEngine;

namespace _Scripts.Weaponds
{
    public class Weapon : WeaponBase
    {
        public override void OnTakeInHand()
        {
            lastShootTime = Time.time + WeaponConfig.slightOfHandTime ;
            Debug.Log("You Take "+ WeaponConfig.type +" to hand");
        }

        public override void OnDownFromHand()
        {
            Debug.Log("You Down "+ WeaponConfig.type +" from hand");
        }

        public override void Use()
        {
            lastShootTime = Time.time;
            
        }
    }
}