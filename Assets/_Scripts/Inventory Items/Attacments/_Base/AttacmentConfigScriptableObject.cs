using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Inventory_Items
{
    
    [CreateAssetMenu(fileName = "Attacment Config", menuName = "Guns/Attacment Configuration")]
    [System.Serializable]
    public class AttacmentConfigScriptableObject : ScriptableObject
    {
        public AttachmentType Type; //how looks gun on game (in player hand)
        public string AttachmentName; //how looks gun on game (in player hand)
        public Sprite InventorySprite; //how looks gun on game (in player hand)
        
        public AttachmentPair Prefabs;
        
        [Range(-99.9f,100f)]
        public float Damage;
        [Range(-100f,100f)]
        public float ArmorPenetration;
        [Range(-90f,100f)]
        public float FireRatePercentage;
        [Range(-90f,200f)]
        public float FireRange;
        [Range(-99.9f,200f)]
        public float SlightOfHandTimePercentage; //if this value is 100, it takes double time
        
    }
    
    public enum AttachmentType {
        Magazine,
        Barrel,
        Muzzle,
        Optic,
        Grip,
        UnderBarrel,
        Ammunition,
        Stock,
        Lazer,
    }

    [System.Serializable]
    public struct AttachmentPair
    {
        public GameObject AttachmentOnGroundAsCollactable;
        public GameObject AttachmentOnCharacterHand;
        
    }

}

