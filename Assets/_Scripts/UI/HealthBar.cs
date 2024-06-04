using System;
using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        private static float lerpSpeed = 0.05f;
        public Slider HealthSlider;
        public Slider HealthEaseSlider;
        public Slider ArmorSlider;
        public Slider ArmorEaseSlider;
        public HealthSystemBase HealthSystem;

        private void Start()
        {
            HealthSystem.OnChange.AddListener(SetChanges);
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HealthSystem.GetDirectDamage(13f);
            }
        }

        private void SetChanges()
        {
            HealthSlider.maxValue = HealthSystem.MaxHealth;
            ArmorSlider.maxValue = HealthSystem.MaxArmor;
            HealthSlider.value = HealthSystem.Health;
            ArmorSlider.value = HealthSystem.Armor;
            
        }
    }
}