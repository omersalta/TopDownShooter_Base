using _Scripts.Items.Base;
using _Scripts.Player;
using _Scripts.Weaponds.Attacments._Base;
using UnityEngine;

namespace _Scripts.Items
{
    public class CollactableItemWeaponAttachment : CollactableItemBase
    {
        [SerializeField] private AttacmentConfigScriptableObject _attacmentConfig;
        public override void TryCollect(ItemCollector itemCollector)
        {
            throw new System.NotImplementedException();
        }
    }
}