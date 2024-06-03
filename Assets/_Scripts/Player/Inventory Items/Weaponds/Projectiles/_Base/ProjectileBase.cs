using System;
using _Scripts.Extensions;
using ToolBox.Pools;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        private Vector3 _shootDirection;
        private float _moveSpeed = 5f;
        
        public virtual void Setup(Vector3 shootDirection, float deadTime)
        {
            //ObjectPooling https://github.com/IntoTheDev/Object-Pooling-for-Unity/releases
            _shootDirection = shootDirection;
            Invoke("Release", deadTime);
            
        }

        private void Release()
        {
            gameObject.Release();
        }
        
        protected virtual void Update()
        {
            transform.position += _shootDirection * _moveSpeed * Time.deltaTime;
        }

        public abstract void RaycastAction(Collider target);
        
    }
}