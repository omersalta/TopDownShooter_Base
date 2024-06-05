using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _Scripts.ShootMechanic.Health_System._Base
{
    public  class HealthSystem
    {
        private float HealthMax; private float ArmorMax;
        
        private float _currentHealth; private float _currentArmor;
        
        public float Health ()  => _currentHealth; 
        public float Armor () => _currentArmor; 
        public float MaxHealth => HealthMax; 
        public float MaxArmor => ArmorMax;
        
        public HealthSystem(float health,float armor)
        {
            _currentHealth = health;
            HealthMax = _currentHealth;
            _currentArmor = armor;
            ArmorMax = _currentArmor;
            //OnChange.Invoke();
        }
        public void Heal(float amount)
        {
            if (_currentHealth < 0f)
            {
                Debug.Log("char already dead");
            }
            _currentHealth += amount;
            if (_currentHealth > HealthMax) HealthMax = _currentHealth;
        }
        
        public void ArmorUp(float amount)
        {
            if (_currentArmor < 0f) _currentArmor = 0f;
            _currentArmor += amount;
            if (_currentArmor > ArmorMax) ArmorMax = _currentArmor;
        }

        public void Damage(float damageAmount, float armorPenRate)
        {
            if (_currentArmor < 0f) _currentArmor = 0f;
            if (armorPenRate > 100f) armorPenRate = 100f;
            
            float healDamage = damageAmount * (armorPenRate / 100f);
            float armorDamage = damageAmount * ((100-armorPenRate) / 100f);
            _currentArmor -= armorDamage;
            if (_currentArmor < 0f)
            {
                healDamage -= _currentArmor;
                _currentArmor = 0;
            }
            
            DirectDamage(healDamage);
        }

        public void DirectDamage(float amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                //Do something
            }
        }

    }
}