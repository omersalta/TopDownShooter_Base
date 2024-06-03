using _Scripts.Player.InventoryItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Items.CollectableItems
{
    public class CollectableAttachment : CollactableBase
    {
       [SerializeField] protected AttacmentConfigScriptableObject attacmentConfig;
        public override void TryCollect(CollectorBase collector)
        {
            
        }
    }
}