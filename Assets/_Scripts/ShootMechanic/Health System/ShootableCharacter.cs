using System;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.ShootMechanic.Health_System
{
    public class ShootableCharacter : ShootableBase,IDamageabale
    {
        [Range(1f, 3000f)]
        [SerializeField] private float health = 100f; 
        
        [Range(1f,2000f)]
        [SerializeField] private float armor = 100f;

        [SerializeField] private GameObject _parentObjeOnDead;
        [SerializeField] private Collider _hitCollider1;
        [SerializeField] private Team _team;
        
        public UnityEvent OnChange;

        public HealthSystem HealthSystem;

        private void Awake()
        {
            _hitCollider1.enabled = true;
            _parentObjeOnDead.SetActive(true);
            HealthSystem = new HealthSystem(health, armor);
            OnChange.Invoke();
        }
        
        public void ResetEnemy()
        {
            _hitCollider1.enabled = false;
            _parentObjeOnDead.SetActive(false);
            Utils.Wait(this,3f , () =>
            {
                Awake();
            });
            
        }
        public float Health()
        {
            return HealthSystem.Health();
        }
        public float Armor()
        {
            return HealthSystem.Armor();
        }

        public void Heal(float amount)
        {
            HealthSystem.Heal(amount);
            OnChange.Invoke();
        }
        public void ArmorUp(float amount)
        {
            HealthSystem.ArmorUp(amount);
        }
        public void Damage(float damageAmount, float armourPenRate)
        {
            HealthSystem.Damage(damageAmount,armourPenRate);
            base.OnShoot();
            OnChange.Invoke();
            if (HealthSystem.Health() <= 0) ResetEnemy();
        }
        public void DirectDamage(float amount)
        {
            HealthSystem.DirectDamage(amount);
            OnChange.Invoke();
        }
        public Team GetTeam()
        {
            return _team;
        }
    }

    public enum Team
    {
        Blue,
        Red,
        None,
    }
}