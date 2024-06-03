using UnityEngine;

namespace _Scripts.Player.InventoryItems.Projectiles
{
    public class Missile : ProjectileBase
    {
        
        public override void RaycastAction(Collider target)
        {
            throw new System.NotImplementedException();
        }
        protected override void Update()
        {
            Debug.Log("name");
        }
    }
}