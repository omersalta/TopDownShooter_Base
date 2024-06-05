
using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.InventoryItems
{
    public class Knife : WeaponBase
    {
        
        public override void OnPickUpFromGround()
        {
            //nothing
        }

        public override void DropAndDestroy()
        {
            FindObjectOfType<UIManager>().SendMessage("knife cannot dropable");
        }
        
        public override bool IsAvailableForAttachment(AttachmentType type)
        {
            FindObjectOfType<UIManager>().SendMessage("knife can not use attachment");
            return false;
        }
        
    }
}