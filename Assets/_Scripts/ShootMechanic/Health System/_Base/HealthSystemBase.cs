using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _Scripts.ShootMechanic.Health_System._Base
{
    public abstract class HealthSystemBase : ShootableBase,IDamageabale
    {
        private float HealthMax; private float ArmorMax;
        
        private float _currentHealth; private float _currentArmor;

        public UnityEvent OnChange;
        public UnityEvent OnDead;
        
        public float Health => _currentHealth; 
        public float Armor => _currentArmor; 
        public float MaxHealth => HealthMax; 
        public float MaxArmor => ArmorMax; 
        
        protected void Initialize(float health,float armor)
        {
            _currentHealth = health;
            HealthMax = _currentHealth;
            _currentArmor = armor;
            ArmorMax = _currentArmor;
        }
        public virtual void Heal(float amount)
        {
            if (_currentHealth < 0f)
            {
                Debug.Log("char already dead");
            }
            _currentHealth += amount;
            if (_currentHealth > HealthMax) HealthMax = _currentHealth;
            OnChange.Invoke();
        }
        
        public void ArmorUp(float amount)
        {
            if (_currentArmor < 0f) _currentArmor = 0f;
            _currentArmor += amount;
            if (_currentArmor > ArmorMax) ArmorMax = _currentArmor;
            OnChange.Invoke();
        }

        public virtual void GetDamage(float damageAmount, float armorPenRate)
        {
            if (_currentArmor < 0f) _currentArmor = 0f;
            if (armorPenRate > 100f) armorPenRate = 100f;
            
            float healDamage = damageAmount * (armorPenRate / 100f);
            float armorDamage = damageAmount - healDamage;
            _currentArmor -= armorDamage;
            if (_currentArmor < 0f) healDamage -= _currentArmor;
            
            GetDirectDamage(healDamage);
        }

        public virtual void GetDirectDamage(float amount)
        {
            _currentHealth -= amount;
            OnChange.Invoke();
            if (_currentHealth <= 0)
            {
                OnCharacterDead();
                //Do something
            }
        }
        public abstract void OnCharacterDead();

    }
}