using _Scripts.Player;
using UnityEngine;


namespace _Scripts.Items.CollectableItems
{
    public abstract class CollactableBase : ItemBase,ICollectable
    {
        private const float rotateSpead = 2.3f;
        public abstract void TryCollect(CollectorBase _collector);

        protected virtual void OnCollect()
        {
            gameObject.SetActive(false);
        }
        
        protected override void Initialize(ItemType type, string name)
        {
            base.Initialize(type,name);
        }
        
        private void Update()
        {
            transform.Rotate(Vector3.up * rotateSpead, Space.Self);
        }
    }
}