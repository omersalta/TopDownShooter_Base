using System;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System._Base;
using ToolBox.Pools;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class ProjectileBase : MonoBehaviour,IPoolable
    {
        protected projectileData data;
        protected float _totalTime = 0f;
        protected float _currentTime;
        private float _multiplayer;
        
        public virtual void Setup(projectileData data)
        {
            this.data = data;
            _totalTime = this.data.MaxRange / data.averageVelocity;
            Mathf.Clamp(this.data.Integrate, 0.1f, 1f);
            _multiplayer = 1 / data.Integrate;
            _currentTime = 0;
            Utils.Wait(this,_totalTime, () =>
            {
                Release();
            });
        }

        protected void Release()
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            _multiplayer = 0;
            Utils.Wait(this,0.4f, () =>
            {
                gameObject.Release();
            });
            
        }
        
        protected virtual void Update()
        {
            float speed = Math.Clamp(data.speedReferance.Evaluate(_currentTime / _totalTime), 0.00001f, 0.97f) * _multiplayer * data.averageVelocity;
            transform.position += data.ShootDirection * speed * Time.deltaTime;
            _currentTime += Time.deltaTime;
        }

        public virtual void HitAction(Collider target)
        {
            target.GetComponent<IShootable>()?.OnShoot();
        }

        public void OnReuse()
        {
            GetComponent<TrailRenderer>().Clear();
            GetComponent<Collider>().enabled = true;
            GetComponent<Renderer>().enabled = true;
        }
        public void OnRelease()
        {
            
        }
    }
}