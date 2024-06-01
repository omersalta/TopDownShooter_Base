using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    [CreateAssetMenu(fileName = "Projectile Behaviour Config", menuName = "Guns/Projectile Configuration")]
    public class ProjectileConfigScriptableObject : ScriptableObject
    {
        public string proectileName;
        public GameObject projectilePrefab; //how looks shoots on game
        
        [Range(10,500)]
        public float Velocity; //min 1 max 100
        
        public AnimationCurve moveBehaviour; //fire per minute    
    }
}