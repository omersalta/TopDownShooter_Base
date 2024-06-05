using System;
using _Scripts.ShootMechanic.Health_System;
using _Scripts.ShootMechanic.Health_System._Base;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider HealthSlider;
        public Slider HealthEaseSlider;
        public Slider ArmorSlider;
        public Slider ArmorEaseSlider;
        public TextMeshProUGUI HealthText;
        public TextMeshProUGUI ArmorText; 
        public ShootableCharacter myCharacter;
        
        public virtual void Start()
        {
            myCharacter.OnChange.AddListener(SetChanges);
            HealthSlider.maxValue = myCharacter.Health();
            HealthEaseSlider.maxValue = myCharacter.Health();
            ArmorSlider.maxValue = myCharacter.Armor();
            ArmorEaseSlider.maxValue = myCharacter.Armor();
            SetChanges();
        }

        public virtual void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }

        private void SetChanges()
        {
            
            HealthSlider.value = myCharacter.Health();
            ArmorSlider.value = myCharacter.Armor();

            float healthDif = HealthEaseSlider.value - HealthSlider.value;
            float armorDif = ArmorEaseSlider.value - ArmorSlider.value;
            
            ArmorEaseSlider.DOKill();
            float additionalTime = armorDif / 60;
            ArmorEaseSlider.DOValue(ArmorSlider.value, 0.40f+Mathf.Clamp(additionalTime,0.1f,3f)).SetEase(Ease.OutQuint);
            HealthEaseSlider.DOKill();
            additionalTime = healthDif / 60;
            HealthEaseSlider.DOValue(HealthSlider.value, 0.40f+Mathf.Clamp(additionalTime,0.1f,3f)).SetEase(Ease.OutQuint);
           
            HealthText.text = myCharacter.Health().ToString(String.Format("0.00"));
            ArmorText.text = myCharacter.Armor().ToString(String.Format("0.00"));
        }
    }   
}