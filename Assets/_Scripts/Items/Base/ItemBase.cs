using UnityEngine;

namespace _Scripts.Items.Base
{
    public abstract class ItemBase : MonoBehaviour
    {
        public ItemType type;
        public string name;
        //todo cursor description ext.
    }
    
    public enum ItemType 
    {
        Weapon,
        Knife,
        Booster,
        HealthPack,
        Letter
    }
}
