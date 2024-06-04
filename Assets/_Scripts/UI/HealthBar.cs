using System;
using _Scripts.ShootMechanic.Health_System._Base;
using DG.Tweening;
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
                HealthSystem.GetDamage(8f,0f);
            }

            if (HealthEaseSlider.value != HealthSlider.value)
            {
                HealthEaseSlider.value = Mathf.Lerp(HealthEaseSlider.value, HealthSlider.value, lerpSpeed);
            }
            
            if (ArmorEaseSlider.value != ArmorSlider.value)
            {
                ArmorEaseSlider.value = Mathf.Lerp(ArmorEaseSlider.value, ArmorSlider.value, lerpSpeed);
            }
            
        }

        private void SetChanges()
        {
            HealthSlider.maxValue = HealthSystem.MaxHealth;
            ArmorSlider.maxValue = HealthSystem.MaxArmor;
            HealthSlider.value = HealthSystem.Health;
            ArmorSlider.value = HealthSystem.Armor;

            float healthDif = HealthEaseSlider.value - HealthSlider.value;
            float armorDif = ArmorEaseSlider.value - ArmorSlider.value;
            ArmorEaseSlider.DOValue(ArmorSlider.value, 0.40f+armorDif/60).SetEase(Ease.OutQuint);
            HealthEaseSlider.DOValue(HealthSlider.value, 0.40f+healthDif/60).SetEase(Ease.OutQuint);
        }
    }   
}