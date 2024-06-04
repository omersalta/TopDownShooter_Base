using Unity.Mathematics;
using UnityEngine;

namespace _Scripts.ShootMechanic.Health_System._Base
{
    public class ShootableBase : MonoBehaviour,IShootable
    {
        [SerializeField] protected GameObject hitParticule;
        
        public virtual void OnShoot()
        {
            if(hitParticule == null) return;
            Instantiate(hitParticule, gameObject.transform.position, quaternion.identity);
        }
    }
}