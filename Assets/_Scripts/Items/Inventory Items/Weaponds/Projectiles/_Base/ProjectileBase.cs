using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected ProjectileConfigScriptableObject _projectileConfig;
        
        public abstract void RaycastAction(Collider target);
        
    }
}