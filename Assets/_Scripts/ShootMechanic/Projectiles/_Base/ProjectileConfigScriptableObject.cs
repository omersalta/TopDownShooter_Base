using System;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Inventory_Items
{
    [CreateAssetMenu(fileName = "Projectile Behaviour Config", menuName = "Guns/Projectile Configuration")]
    public class ProjectileConfigScriptableObject : ScriptableObject
    {
        public string ProectileName;
        public GameObject ProjectilePrefab; //how looks shoots on game
        public AnimationCurve SpeedReferance; //fire move behavior, it must be start time= 0 to time = 1

        public float CurveIntegrate;
        
        private void OnValidate()
        {
            CurveIntegrate = Utils.IntegrateCurve(SpeedReferance, 0, 1, 1000);
        }
    }

    public struct projectileData
    {
        public float Damage, ArmorPenetrationRate, MaxRange, averageVelocity,Integrate;
        public AnimationCurve speedReferance;
        public Vector3 ShootDirection;
        public Team shooterTeam;

        public projectileData(float damage, float armorPenetrationRate, float maxRange, float averageVelocity, float integrate, AnimationCurve speedReferance, Vector3 shootDirection, Team team)
        {
            Damage = damage;
            ArmorPenetrationRate = armorPenetrationRate;
            MaxRange = maxRange;
            Integrate = integrate;
            this.averageVelocity = averageVelocity;
            this.speedReferance = speedReferance;
            ShootDirection = shootDirection;
            shooterTeam = team;
        }
    }
}