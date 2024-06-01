using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public abstract class DropableItemBase : InventoryItemBase
    {
        [SerializeField] protected GameObject _dropSpawnPrefab;

        public abstract void OnDropFromHand();

    }
}