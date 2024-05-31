using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public abstract class InventoryItemBase : MonoBehaviour
    {
        [SerializeField] protected Sprite _inventorySprite;
        
        public abstract void Use();
        
        public virtual void OnDownFromHand()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnTakeInHand()
        {
            gameObject.SetActive(true);
        }

    }
    
}