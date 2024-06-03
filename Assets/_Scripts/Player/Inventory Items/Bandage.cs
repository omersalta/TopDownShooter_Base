
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    public class Bandage : MainInventoryItemBase
    {
        [Range(1,100)]
        [SerializeField] private float _healthAmount;
        
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
        
    }
}