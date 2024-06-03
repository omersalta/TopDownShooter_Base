
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class Bandage : MainInventoryItemBase
    {
        [Range(1,100)]
        [SerializeField] private float healthAmount;
        
        public override void OnPickUpFromGround()
        {
            throw new System.NotImplementedException();
        }

        public override void OnDownFromHand()
        {
            throw new System.NotImplementedException();
        }

        public override void OnTakeInHand()
        {
            throw new System.NotImplementedException();
        }

        public override void Use(InventoryBase user)
        {
            throw new System.NotImplementedException();
        }
    }
}