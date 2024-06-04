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
        protected float _moveSpeed = 0f;
        protected float _totalTime = 0f;
        protected float _currentTime;
        
        public virtual void Setup(projectileData data)
        {
            this.data = data;
            _totalTime = this.data.MaxRange / data.averageVelocity;
            _moveSpeed = data.averageVelocity;
            _currentTime = 0;
            Utils.Wait(this,_totalTime, () =>
            {
                Release();
            });
        }

        protected void Release()
        {
            _moveSpeed = 0;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Utils.Wait(this,0.4f, () =>
            {
                gameObject.Release();
            });
            
        }
        
        protected virtual void Update()
        {
            Debug.Log(_moveSpeed);
            transform.position += data.ShootDirection * _moveSpeed * Time.deltaTime;
            _currentTime += Time.deltaTime;
            //Debug.Log("_currentTime:" + _currentTime + ",   _totalTime:" + _totalTime + "------speedRef:" + data.speedReferance.Evaluate(_currentTime/_totalTime));
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