using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class RocketLauncher : WeaponBase
    {
        public override void Use(InventoryBase user)
        {
            throw new System.NotImplementedException();
        }
        
        public override bool isAvailableForAttachment(AttachmentType _type)
        {
            if (_type == AttachmentType.Ammunition || _type == AttachmentType.Magazine ||
                _type == AttachmentType.Muzzle || _type == AttachmentType.Stock) return false;
            
            return base.isAvailableForAttachment(_type);
        }

        public override void OnPickUpFromGround()
        {
            //nothing
        }
    }
}
