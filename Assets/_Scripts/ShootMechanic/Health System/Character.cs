using System;
using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;

namespace _Scripts.ShootMechanic.Health_System
{
    public class Character : HealthSystemBase
    {
        [Range(1f, 200f)]
        [SerializeField] private float health = 100f; 
        
        [Range(1f,200f)]
        [SerializeField] private float armor = 100f; 
        
        private void Awake()
        {
            Initialize(health,armor);
        }
        public override void OnCharacterDead()
        {
            Debug.Log("ım dead");
        }
    }
}