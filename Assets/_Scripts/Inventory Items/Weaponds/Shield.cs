using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class Shield : WeaponBase
    {
        public override bool IsAvailableForAttachment(AttachmentType type)
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