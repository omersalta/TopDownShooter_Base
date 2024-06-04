using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public class Bullet : ProjectileBase
    {
        public override void HitAction(Collider target)
        {
            base.HitAction(target);
            target.GetComponent<IDamageabale>()?.GetDamage(data.Damage,data.ArmorPenetrationRate);
        }
    }
}