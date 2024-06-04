using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public abstract class CollectorBase : MonoBehaviour
    {
        public InventoryBase Inventory;
        public virtual void OnTriggerEnter(Collider other)
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