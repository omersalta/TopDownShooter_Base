using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public interface IDropable
    {
        public abstract void Drop(Vector3 dropPosition);
    }
}