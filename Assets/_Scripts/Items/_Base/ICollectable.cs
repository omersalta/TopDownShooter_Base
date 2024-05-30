using _Scripts.Player;

namespace _Scripts.Items.Base
{
    public interface ICollectable
    {
        void TryCollect(ItemCollector itemCollector);

        void OnCollect();

    }
}