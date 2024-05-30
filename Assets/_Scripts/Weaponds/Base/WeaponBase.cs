using _Scripts.Weaponds.Bullets;
using UnityEngine;


namespace _Scripts.Weaponds
{
    public abstract class WeaponBase
    {
        public WeaponConfigScriptableObject WeaponConfig;
        public ProjectileBase projectile;
        protected float lastShootTime;
        
        public abstract void OnTakeInHand();
        public abstract void OnDownFromHand();
        public abstract void Use();

    }
}