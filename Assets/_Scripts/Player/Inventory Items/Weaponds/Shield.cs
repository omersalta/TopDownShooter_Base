using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class Shield : WeaponBase
    {
        public override void Use(InventoryBase user)
        {
            
        }
        public override bool isAvailableForAttachment(AttachmentType type)
        {
            Debug.Log("Shields cannot mount attachments");
            return false;
        }

        public override void OnPickUpFromGround()
        {
            //nothing
        }
    }
}