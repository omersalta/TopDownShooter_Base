using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerItemCollector : MonoBehaviour
    {
        public PlayerInventory PlayerInventory;
        //public HealthBar;
        
        private void OnTriggerEnter(Collider other)
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