using _Scripts.Player;

namespace _Scripts.Items.Base
{
    public interface IInventoryItem
    {
        public void Use();
        public void OnTakeInHand();
        public void OnDownFromHand();

    }
    
}