using _Scripts.Player;

namespace _Scripts.Items.CollectableItems
{
    public abstract class NonInventoryCollectableBase : CollactableBase
    {
        protected override void Initialize(ItemType type, string name)
        {
            base.Initialize(type, name);
        }
    }
}