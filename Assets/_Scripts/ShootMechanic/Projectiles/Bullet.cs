using System;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System._Base;
using ToolBox.Pools;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public class Bullet : ProjectileBase,IPoolable
    {
        public override void Setup(projectileData data)
        {
            base.Setup(data);
            
            Utils.Wait(this,_totalTime, () =>
            {
                _multiplayer = 0;
                StopBullet();
            });
        }
        
        protected void StopBullet()
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            _multiplayer = 0;
            Utils.Wait(this,0.35f, () =>
            {
                gameObject.Release();
            });
            
        }
        
        protected virtual void FixedUpdate()
        {
            float speed = Math.Clamp(data.speedReferance.Evaluate(_currentTime / _totalTime), 0.01f, 0.98f) * _multiplayer * data.averageVelocity;
            transform.position += data.ShootDirection * speed * (Time.deltaTime/2);
            _currentTime += Time.deltaTime;
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
        public void OnTriggerEnter(Collider target)
        {
            IDamageabale iDamage = target.GetComponent<IDamageabale>();
            if (iDamage != null && iDamage.GetTeam() != data.shooterTeam)
            {
                target.GetComponent<IDamageabale>()?.Damage(data.Damage,data.ArmorPenetrationRate);
                gameObject.Release();
            }
        }
    }
}