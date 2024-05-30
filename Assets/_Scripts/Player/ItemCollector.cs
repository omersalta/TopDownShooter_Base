using System;
using _Scripts.Items.Base;
using UnityEngine;

namespace _Scripts.Player
{
    public class ItemCollector : MonoBehaviour
    {
        public PlayerInventory PlayerInventory;
        public PlayerInventory HealthBar;

        private void OnCollisionEnter(Collision other)
        {
            ICollectable item = other.gameObject.GetComponent<ICollectable>();
            if (item != null)
            {
                item.TryCollect(this);
            }
        }
    }
}