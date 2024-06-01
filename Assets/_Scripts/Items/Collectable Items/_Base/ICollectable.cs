using _Scripts.Player;

namespace _Scripts.Items.CollectableItems
{
    public interface ICollectable
    {
        void TryCollect(CollectorBase playerCollector);

        void OnCollect();

    }
}