using _Scripts.Items.CollectableItems;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    public abstract class AttachmentBase : InventoryNonUsableItemBase
    { 
        [SerializeField] public AttacmentConfigScriptableObject AttacmentConfig;
    }
    
}