using _Scripts.Items.Base;
using UnityEngine;


namespace _Scripts.Weaponds
{
    public abstract class WeaponBase : InventoryItemBase
    {
        protected WeaponConfigScriptableObject _weaponConfig;
        protected float lastShootTime;
        
        public abstract void RaycastAction(Collider target);
        
    }
}