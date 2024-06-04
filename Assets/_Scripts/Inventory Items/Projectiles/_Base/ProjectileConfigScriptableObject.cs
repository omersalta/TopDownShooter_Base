using System;
using _Scripts.Extensions;
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
        public float Damage, ArmorPenetrationRate, MaxRange, averageVelocity;
        public AnimationCurve speedReferance;
        public Vector3 ShootDirection;

        public projectileData(float damage, float armorPenetrationRate, float maxRange, float averageVelocity, AnimationCurve speedReferance, Vector3 shootDirection)
        {
            Damage = damage;
            ArmorPenetrationRate = armorPenetrationRate;
            MaxRange = maxRange;
            this.averageVelocity = averageVelocity;
            this.speedReferance = speedReferance;
            ShootDirection = shootDirection;
        }
    }
}