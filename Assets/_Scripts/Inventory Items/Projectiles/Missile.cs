using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public class Missile : ProjectileBase
    {
        
        public override void HitAction(Collider target)
        {
            //TODO damage every targets
        }
        protected override void Update()
        {
            Debug.Log("name");
        }
    }
}