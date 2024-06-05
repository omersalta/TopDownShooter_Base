using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class InventoryNonUsableItemBase : ItemBase,IDropable
    { 
        protected Sprite inventorySprite;
        protected GameObject dropSpawnGameObject;
        
        public abstract void OnPickUpFromGround();
        public abstract void OnDownFromHand();
        
        public abstract void OnTakeInHand();
        
        public virtual void DropAndDestroy()
        {
            dropSpawnGameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    
    
    /*[System.Serializable]
    public struct InventorySubItemBaseData
    {
        public Sprite InventorySprite;
        public GameObject DropSpawnPrefab;
        public ItemType Type;
        public string Name;

        public InventorySubItemBaseData(Sprite sprite, GameObject dropPrefab, ItemType type, string name)
        {
            Type = type;
            Name = name;
            DropSpawnPrefab = dropPrefab;
            InventorySprite = sprite;
        }
    }*/
}