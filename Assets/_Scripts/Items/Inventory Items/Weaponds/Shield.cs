﻿using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public class Shield : WeaponBase
    {
        public override void Use()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDropFromHand()
        {
            throw new System.NotImplementedException();
        }

        public override bool isAvailableForAttachment(AttachmentType type)
        {
            return false;
        }
        
    }
}