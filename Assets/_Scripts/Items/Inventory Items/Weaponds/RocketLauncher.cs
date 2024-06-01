using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public class RocketLauncher : WeaponBase
    {
        public override void Use()
        {
            throw new System.NotImplementedException();
        }

        public override void OnTakeInHand()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDropFromHand()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDownFromHand()
        {
            throw new System.NotImplementedException();
        }

        public override bool isAvailableForAttachment(AttachmentType _type)
        {
            if (_type == AttachmentType.Ammunition || _type == AttachmentType.Magazine ||
                _type == AttachmentType.Muzzle || _type == AttachmentType.Stock) return false;
            
            return base.isAvailableForAttachment(_type);
        }
    }
}
