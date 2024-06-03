using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    [CreateAssetMenu(fileName = "Projectile Behaviour Config", menuName = "Guns/Projectile Configuration")]
    public class ProjectileConfigScriptableObject : ScriptableObject
    {
        public string proectileName;
        public GameObject projectilePrefab; //how looks shoots on game
        
        [FormerlySerializedAs("Velocity")] [Range(10,500)]
        public float averageVelocity; //avarage valocity for reach max distance
        
        public AnimationCurve moveBehaviour; //fire move behavior  
    }
}