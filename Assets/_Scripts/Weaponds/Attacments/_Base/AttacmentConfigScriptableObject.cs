using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weaponds.Attacments._Base
{
    
    [CreateAssetMenu(fileName = "Attacment Config", menuName = "Guns/Attacment Configuration")]
    public class AttacmentConfigScriptableObject : ScriptableObject
    {
        public String attachmentName; //how looks shoots on game
        public AttachmentType type; //how looks gun on game (in player hand)
        
        [Range(1,25)]
        public int damage;
        [Range(0,100)]
        public int armorPenetrationRate;
        [Range(20,500)]
        public int fireRate;
        [Range(20f,300f)]
        public float fireRange;
        [Range(0,100f)]
        public float slightOfHandTimePercentage;
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

