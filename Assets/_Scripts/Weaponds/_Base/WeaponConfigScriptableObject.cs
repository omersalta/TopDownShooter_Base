using System.Collections.Generic;
using _Scripts.Weaponds.Attacments._Base;
using UnityEngine;

    [CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Weapon Configuration")]
    public class WeaponConfigScriptableObject : ScriptableObject
    {
        public string weaponName; // name of unique gun
        public List<AttachmentPair> currentMountedAttachments; //
        
        public GameObject weaponPrefab; //how looks gun on player hand
        public GameObject projectilePrefab; //how looks shoots on game
        
        [Range(1,100)]
        public int damage; //min 1 max 100
        [Range(0,100)]
        public int armorPenetrationRate; //min 0 max 100
        [Range(20,500)]
        public int fireRate; //fire per minute
        [Range(20f,300f)]
        public float fireRange; //missile distance
        [Range(0.1f,2f)]
        public float slightOfHandTime; //the waiting time before you can use it when you pick it up
    }



[System.Serializable]
public struct AttachmentPair {
    public AttachmentType type;
    public AttacmentConfigScriptableObject attacmentConfig;
}