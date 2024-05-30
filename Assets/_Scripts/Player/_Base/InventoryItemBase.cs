using System;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.Base
{
    public abstract class InventoryItemBase : MonoBehaviour
    {
        [SerializeField] protected Sprite _inventorySprite;
        
        public abstract void Use();
        public abstract void OnTakeInHand();
        public abstract void OnDownFromHand();

    }
    
}