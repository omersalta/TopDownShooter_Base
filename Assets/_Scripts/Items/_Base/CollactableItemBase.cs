using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.Base
{
    public abstract class CollactableItemBase : ItemBase, ICollectable
    {
        public abstract void TryCollect(ItemCollector itemCollector);
        
        public virtual void OnCollect()
        {
            Debug.Log("Base Class On Collect");
            gameObject.SetActive(false); //todo object pooling
        }
    }
}