using _Scripts.Player;
using UnityEngine;


namespace _Scripts.Items.CollectableItems
{
    public abstract class CollactableBase : ItemBase,ICollectable
    {
        private const float RotateSpead = 2.3f;
        public abstract void TryCollect(CollectorBase collector);

        protected virtual void OnCollect()
        {
            gameObject.SetActive(false);
        }
        
        private void Update()
        {
            transform.Rotate(Vector3.up * RotateSpead, Space.Self);
        }
    }
}