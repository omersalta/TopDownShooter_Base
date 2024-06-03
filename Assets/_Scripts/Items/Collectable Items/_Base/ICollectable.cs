using _Scripts.Player;

namespace _Scripts.Items.CollectableItems
{
    public interface ICollectable
    {
        public void TryCollect(CollectorBase collector);
    }
}