using _Scripts.Player;


namespace _Scripts.Items.CollectableItems
{
    public abstract class CollactableItemBase : ItemBase, ICollectable
    {
        public abstract void TryCollect(PlayerItemCollector playerItemCollector);
        
        public virtual void OnCollect()
        {
            gameObject.SetActive(false); //todo object pooling
        }
    }
}