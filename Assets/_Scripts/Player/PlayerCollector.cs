using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerCollector : CollectorBase
    {
        public PlayerInventory PlayerInventory;
        //public HealthBar;
        
        public override void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            if (collectable != null)
            {
                print("Collision enter: " + gameObject.name);
                collectable.TryCollect(this);
            }
        }
        
        
    }
}