using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public abstract class InventoryBase : MonoBehaviour
    {
        public abstract bool IsInventoryAvailable();
        public abstract bool IsInventoryAvailableForNonUsable();
        public abstract bool PickUpFromGround(MainInventoryItemBase newItem);
        public abstract bool PickUpSubItem(InventoryNonUsableItemBase newItem);
        
    }
}