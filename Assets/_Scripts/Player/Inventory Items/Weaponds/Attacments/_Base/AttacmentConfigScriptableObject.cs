using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    
    [CreateAssetMenu(fileName = "Attacment Config", menuName = "Guns/Attacment Configuration")]
    public class AttacmentConfigScriptableObject : ScriptableObject
    {
        public InventorySubItemBaseData AttachmentData; //how looks shoots on game
        public AttachmentType Type; //how looks gun on game (in player hand)
        
        [Range(-99.9f,200f)]
        public float DamagePercentage;
        [Range(-99.9f,200f)]
        public float ArmorPenetrationRatePercentage;
        [Range(-99.9f,100f)]
        public float FireRatePercentage;
        [Range(-99.9f,300f)]
        public float FireRangePercentage;
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


}

