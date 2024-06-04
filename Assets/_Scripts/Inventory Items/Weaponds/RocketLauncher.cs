using _Scripts.Inventory_Items;
using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class RocketLauncher : WeaponBase
    {
        public override bool IsAvailableForAttachment(AttachmentType type)
        {
            if (type == AttachmentType.Ammunition || type == AttachmentType.Magazine ||
                type == AttachmentType.Muzzle || type == AttachmentType.Stock) return false;
            
            return base.IsAvailableForAttachment(type);
        }

        public override void OnPickUpFromGround()
        {
            //nothing
        }
    }
}
