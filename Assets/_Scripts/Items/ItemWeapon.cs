using _Scripts.Items.Base;
using _Scripts.Player;
using _Scripts.Weaponds;

namespace _Scripts.Items
{
    public class ItemWeapon : CollactableItemBase,IInventoryItem
    {
        public Weapon _weapon;
        
        public void Use()
        {
            _weapon.Use();
        }
        
        public override void TryCollect(ItemCollector itemCollector)
        {
            if (itemCollector.PlayerInventory.TryPickUp(this))
            {
               OnCollect();
            }
        }

        public void OnTakeInHand()
        {
            throw new System.NotImplementedException();
        }

        public void OnDownFromHand()
        {
            throw new System.NotImplementedException();
        }
    }
}