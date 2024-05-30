using _Scripts.Player;

namespace _Scripts.Items.Base
{
    public abstract class CollactableItemBase : ItemBase, ICollectable
    {
        public abstract void TryCollect(ItemCollector itemCollector);
        
        public void OnCollect()
        {
            gameObject.SetActive(false); //todo object pooling
        }
    }
}