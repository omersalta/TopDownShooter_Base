using _Scripts.Inventory_Items;
using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class Bandage : MainInventoryItemBase
    {
        private float _healthAmount;
        
        public virtual void InitializeBandage(float healthAmount,GameObject dropReferance,Sprite inventorySprite, float reuseCooldown)
        {
            reuseCooldownValueInSeconds = reuseCooldown;
            _healthAmount = healthAmount;
            dropSpawnGameObject = dropReferance;
            this.inventorySprite = inventorySprite;
            
        }
        
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
            HealthSystem healthSystem = user.GetComponent<HealthSystem>();
            if(healthSystem == null) return;
            
            healthSystem.Heal(_healthAmount);
        }

    }
}