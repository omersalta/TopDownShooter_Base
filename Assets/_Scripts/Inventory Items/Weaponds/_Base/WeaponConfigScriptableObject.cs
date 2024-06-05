using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Inventory_Items
{
    [CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Weapon Configuration")]
    public class WeaponConfigScriptableObject : ScriptableObject
    {
        public string WeaponName; // name of unique gun

        public WeaponPair Prefabs;
        
        public ProjectileConfigScriptableObject ProjectileConfig; //how looks shoots on game
        
        [Range(1f,100f)]
        public float Damage; //damage value
        [Range(0f,100f)]
        public float ArmorPenetrationRate; //armor penetration value
        [Range(20f,1500f)]
        public float FireRate; //fire per minute
        [Range(2f,70f)]
        public float Range; //maximum projectile range distance it can reach
        [Range(20f,75f)]
        public float PrejctileSpeed; //maximum projectile range distance it can reach
        [Range(0.1f,2f)]
        public float SlightOfHandTime; //the waiting time required to use the equipment once you take it in your hands
    }

    [System.Serializable]
    public struct WeaponPair
    {
        public GameObject WeaponOnGroundAsCollactable;
        public GameObject WeaponOnCharacterHand;
        
    }
    
    
}
