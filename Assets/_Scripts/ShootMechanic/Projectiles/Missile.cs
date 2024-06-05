using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System._Base;
using ToolBox.Pools;
using Unity.Mathematics;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public class Missile : ProjectileBase
    {
        private List<Collider> _impactedEnemys = new List<Collider>();
        [SerializeField] private float _impactArea;
        [SerializeField] private float _triggerArea;
        [SerializeField] private float _explosionCooldown;
        
        private float _speed;
        
        bool IsExploded = false;

        [SerializeField] private GameObject _explosionParticule;
        public void OnTriggerStay(Collider target)
        {
            IDamageabale enemy = target.GetComponent<IDamageabale>();
            
            if (enemy != null)
            {
                if(enemy.GetTeam() == data.shooterTeam) return;
                bool containsItem = _impactedEnemys.Any(item => item == target);
                if(!containsItem)_impactedEnemys.Add(target);
                float dist = Vector3.Distance(target.gameObject.transform.position, transform.position);
                
                if (dist < _triggerArea)
                {
                    Debug.Log("gonnna explode");
                    Utils.Wait(this,_explosionCooldown/(_speed/10), () =>
                    {
                        
                        Explode();
                    });
                }
            }
        }

        public override void Setup(projectileData data)
        {
            IsExploded = false;
            _impactedEnemys.Clear();
            base.Setup(data);
            transform.right = data.ShootDirection;
            
            Utils.Wait(this,_totalTime, () =>
            {
                _multiplayer = 0;
                Explode();
            });
        }

        protected virtual void FixedUpdate()
        {
            _speed = Math.Clamp(data.speedReferance.Evaluate(_currentTime / _totalTime), 0.1f, 0.9f) * _multiplayer * data.averageVelocity;
            transform.position += data.ShootDirection * _speed * (Time.deltaTime/2);
            _currentTime += Time.deltaTime;
        }

        private void Explode()
        {
            if(IsExploded) return;
            Debug.Log("Exploodinnggg");
            IsExploded = true;
            var particule = _explosionParticule.Reuse(transform.position,quaternion.identity);
            foreach (var enemy in _impactedEnemys)
            {
                Debug.Log("exploded :" + enemy.gameObject.name);
                float dist = Vector3.Distance(enemy.gameObject.transform.position, transform.position);
                Debug.Log(enemy + " distance :" + dist);
                if (dist < _impactArea)
                {
                    enemy.GetComponent<IDamageabale>().Damage(data.Damage,data.ArmorPenetrationRate);
                }
            }
            gameObject.Release();
        }


        public void OnReuse()
        {
            throw new NotImplementedException();
        }
        public void OnRelease()
        {
            throw new NotImplementedException();
        }
    }
}