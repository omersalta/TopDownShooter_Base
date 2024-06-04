using _Scripts.Inventory_Items;
namespace _Scripts.Player
{
    public class PlayerInventory : InventoryBase
    {
        protected override void Start()
        {
            base.Start();
            FindObjectOfType<PlayerInput>().MouseDownEvent.AddListener(OnMouseDown);
            FindObjectOfType<PlayerInput>().MouseUpEvent.AddListener(OnMouseUp);
            FindObjectOfType<PlayerInput>().KeyCode.AddListener(TryTakeHand);
        }
        
        
        public override bool IsInventoryAvailable()
        {
            return items.ContainsValue(null);
        }

        public override bool IsInventoryAvailableForNonUsable()
        {
            return true;
        }
        
    }
}