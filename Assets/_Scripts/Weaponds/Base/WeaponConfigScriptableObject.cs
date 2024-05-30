using UnityEngine;

    [CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Weapon Configuration")]
    public class WeaponConfigScriptableObject : ScriptableObject
    {
        public GunType type; // name of unique gun
        
        public GameObject weaponPrefab; //how looks gun on game (in player hand)
        
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


public enum GunType 
{
    Pistol,
    Rifle,
    RocketLauncher
}