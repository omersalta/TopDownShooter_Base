﻿using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class InventoryNonUsableItemBase : ItemBase,IDropable
    { 
        protected readonly Vector3 dropOffset = new Vector3(3f, 1f, 0);
        
        protected Sprite inventorySprite;
        protected GameObject dropSpawnPrefab;
        
        public abstract void OnPickUpFromGround();
        public abstract void OnDownFromHand();
        
        public abstract void OnTakeInHand();
        
        public virtual void Drop(Vector3 dropPosition)
        {
            dropSpawnPrefab.SetActive(true);
            dropSpawnPrefab.transform.position = dropPosition;
            Destroy(gameObject);
        }
        
        public void InitializeInventorySubItem (InventorySubItemBaseData data)
        {
            base.Initialize(data.Type,data.Name);
            dropSpawnPrefab = data.DropSpawnPrefab;
            inventorySprite = data.InventorySprite;
        }
    }

    
    
    [System.Serializable]
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
    }
}