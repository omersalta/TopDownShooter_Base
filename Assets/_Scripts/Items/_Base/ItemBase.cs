using System;
using UnityEngine;

namespace _Scripts.Items.Base
{
    public abstract class ItemBase : MonoBehaviour
    {
        public ItemType type;
        public string name;
        //todo cursor description ext.

        private const float rotateSpead = 2.3f;

        private void Update()
        {
            transform.Rotate(Vector3.up * rotateSpead, Space.Self);
        }
    }
    
    
    
    public enum ItemType 
    {
        Weapon,
        Booster,
        HealthKit,
        Interactable,
        WeaponAttachment,
    }
}
