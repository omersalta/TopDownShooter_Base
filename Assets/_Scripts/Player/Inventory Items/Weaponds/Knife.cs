using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class Knife : WeaponBase
    {
        
        public override void Use(InventoryBase user)
        {
            
        }

        public override void OnPickUpFromGround()
        {
            //nothing
        }

        public override void Drop(Vector3 dropPosition)
        {
            Debug.Log("knife cannot dropable");
            
        }
        
        public override bool isAvailableForAttachment(AttachmentType type)
        {
            Debug.Log("knife can not use attachment");
            return false;
        }
        
    }
}