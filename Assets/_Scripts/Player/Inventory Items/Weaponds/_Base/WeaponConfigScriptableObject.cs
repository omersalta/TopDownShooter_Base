using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    [CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Weapon Configuration")]
    public class WeaponConfigScriptableObject : ScriptableObject
    {
        public string weaponName; // name of unique gun
        public List<AttachmentBase> currentMountedAttachments; //list of mounted attachment
        public GameObject playerWeaponPrefab; //how looks gun on player hand
        public ProjectileConfigScriptableObject ProjectileConfig; //how looks shoots on game
        
        [Range(1,100)]
        public float damage; //damage value
        [Range(0,100)]
        public float armorPenetrationRate; //armor penetration value
        [Range(20,500)]
        public float fireRate; //fire per minute
        [Range(20f,300f)]
        public float fireRange; //maximum projectile range distance it can reach
        [Range(50f,300f)]
        public float prejctileSpeed; //maximum projectile range distance it can reach
        [Range(0.1f,2f)]
        public float slightOfHandTime; //the waiting time required to use the equipment once you take it in your hands
        
        
        
    }
    
}
