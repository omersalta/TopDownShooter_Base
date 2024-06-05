using Unity.Mathematics;
using UnityEngine;

namespace _Scripts.ShootMechanic.Health_System._Base
{
    public class ShootableBase : MonoBehaviour
    {
        [SerializeField] protected GameObject hitParticule;
        
        public virtual void OnShoot()
        {
            if(hitParticule == null) return;
            if (hitParticule.TryGetComponent<ParticleSystem>(out ParticleSystem particuleSystem))
            {
                Instantiate(hitParticule, transform.position, quaternion.identity);
            }
        }
    }
}