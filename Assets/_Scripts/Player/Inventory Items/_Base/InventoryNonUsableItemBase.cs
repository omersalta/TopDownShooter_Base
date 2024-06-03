using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public abstract class InventoryNonUsableItemBase : ItemBase,IDropable
    {
        protected readonly Vector3 dropOffset = new Vector3(3f, 1f, 0);
        [SerializeField] protected Sprite _inventorySprite;
        [SerializeField] protected GameObject _dropSpawnPrefab;
        
        public abstract void OnPickUpFromGround();
        public abstract void OnDownFromHand();
        
        public abstract void OnTakeInHand();
        
        public virtual void Drop(Vector3 dropPosition)
        {
            _dropSpawnPrefab.SetActive(true);
            _dropSpawnPrefab.transform.position = dropPosition;
            Destroy(gameObject);
        }
        
        public void InitializeInventorySubItem (InventorySubItemBaseData data)
        {
            base.Initialize(data.Type,data.Name);
            _dropSpawnPrefab = data.DropSpawnPrefab;
            _inventorySprite = data.InventorySprite;
        }
    }

    
    
    
    public struct InventorySubItemBaseData
    {
        public Sprite InventorySprite;
        public GameObject DropSpawnPrefab;
        public ItemType Type;
        public string Name;

        public InventorySubItemBaseData(Sprite Sprite, GameObject dropPrefab, ItemType type, string name)
        {
            Type = type;
            Name = name;
            DropSpawnPrefab = dropPrefab;
            InventorySprite = Sprite;
        }
    }
}