using System;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    
    [CreateAssetMenu(fileName = "Attacment Config", menuName = "Guns/Attacment Configuration")]
    public class AttacmentConfigScriptableObject : ScriptableObject
    {
        public InventorySubItemBaseData AttachmentData; //how looks shoots on game
        public AttachmentType type; //how looks gun on game (in player hand)
        
        [Range(-99.9f,200f)]
        public float damagePercentage;
        [Range(-99.9f,200f)]
        public float armorPenetrationRatePercentage;
        [Range(-99.9f,100f)]
        public float fireRatePercentage;
        [Range(-99.9f,300f)]
        public float fireRangePercentage;
        [Range(-99.9f,200f)]
        public float slightOfHandTimePercentage; //if this value is 100, it takes double time
        
        
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

