using UnityEngine;

namespace _Scripts.Weaponds.Bullets
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        public GameObject projectilePrefab; //how looks shoots on game
        
        public abstract void RaycastAction(Collider target);
    }
}