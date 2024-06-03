using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    [CreateAssetMenu(fileName = "Projectile Behaviour Config", menuName = "Guns/Projectile Configuration")]
    public class ProjectileConfigScriptableObject : ScriptableObject
    {
        public string ProectileName;
        public GameObject ProjectilePrefab; //how looks shoots on game
        [Range(10,500)]
        public float AverageVelocity; //avarage valocity for reach max distance
        public AnimationCurve MoveBehaviour; //fire move behavior  
    }
}