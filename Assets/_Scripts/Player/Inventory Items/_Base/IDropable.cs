using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public interface IDropable
    {
        public abstract void Drop(Vector3 dropPosition);
    }
}