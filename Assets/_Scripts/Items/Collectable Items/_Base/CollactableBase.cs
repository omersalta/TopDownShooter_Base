using _Scripts.Player;


namespace _Scripts.Items.CollectableItems
{
    public abstract class CollactableBase : ItemBase
    {
        public abstract void TryCollect(CollectorBase _collector);
        
        public virtual void OnCollect()
        {
            gameObject.SetActive(false); //todo object pooling
        }
    }
}