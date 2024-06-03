using _Scripts.Player.InventoryItems;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class CollectableAttachment : CollactableBase
    {
        [SerializeField] protected AttacmentConfigScriptableObject _attacmentConfig;
        public override void TryCollect(CollectorBase _collector)
        {
            
        }
    }
}