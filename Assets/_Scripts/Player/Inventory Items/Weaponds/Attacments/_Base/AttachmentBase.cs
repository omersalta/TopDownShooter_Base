using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public abstract class AttachmentBase : InventoryNonUsableItemBase
    { 
        [SerializeField] public AttacmentConfigScriptableObject _attacmentConfig;
    }
    
}