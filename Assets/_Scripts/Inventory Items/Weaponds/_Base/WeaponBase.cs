using System.Collections.Generic;
using System.Linq;
using _Scripts.Player;
using UnityEngine;
using ToolBox.Pools;
using Unity.Mathematics;


namespace _Scripts.Inventory_Items
{
    public abstract class WeaponBase : MainInventoryItemBase
    {
        [SerializeField] protected WeaponConfigScriptableObject defaultWeaponConfig;
        protected WeaponConfigScriptableObject weaponConfig;
        [SerializeField] protected Dictionary<AttachmentType, AttachmentBase> currentMountedAttachments = new Dictionary<AttachmentType, AttachmentBase>();
        
        public virtual void InitializeWeapon(WeaponConfigScriptableObject Config)
        {
            this.defaultWeaponConfig = Config;
            weaponConfig = Instantiate(defaultWeaponConfig);
            reuseCooldownValueInSeconds = 60 / weaponConfig.FireRate;
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            currentMountedAttachments.Clear();
        }

        public virtual GameObject GetProjectileFromPool()
        {
            return Instantiate(weaponConfig.ProjectileConfig.ProjectilePrefab, transform.position, quaternion.identity);
            return weaponConfig.ProjectileConfig.ProjectilePrefab.Reuse(transform.position,quaternion.identity);
        }
        
        protected virtual Vector3 GetAimPosition()
        {
            return PlayerInput.PlayerMouseCursor;
        }
        
        public virtual bool IsAvailableForAttachment(AttachmentType type){
            
            bool contains = currentMountedAttachments.Any(pair => pair.Key == type);
            return !contains;
        }
        
        public virtual void AddAttachment(AttachmentBase attacment)
        {
            AttacmentConfigScriptableObject config = attacment.AttacmentConfig;
            
            weaponConfig.Damage = defaultWeaponConfig.Damage * ((100f + config.DamagePercentage)/100);
            weaponConfig.ArmorPenetrationRate = defaultWeaponConfig.ArmorPenetrationRate * ((100f + config.ArmorPenetrationRatePercentage)/100);
            weaponConfig.FireRate = defaultWeaponConfig.FireRate * ((100f + config.FireRatePercentage)/100);
            weaponConfig.Range = defaultWeaponConfig.Range * ((100f + config.FireRangePercentage)/100);
            weaponConfig.SlightOfHandTime = defaultWeaponConfig.SlightOfHandTime * (config.SlightOfHandTimePercentage/100f);
            currentMountedAttachments.Add(config.Type,attacment);
        }
        
        public override void OnTakeInHand()
        {
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            base.OnTakeInHand();
        }
        
        public override void Drop(Vector3 dropPosition)
        {
            foreach (KeyValuePair<AttachmentType, AttachmentBase> pair in currentMountedAttachments)
            {
                pair.Value.Drop(dropPosition);
                dropPosition += dropOffset;
            }
           
            weaponConfig = null;
            base.Drop(dropPosition);
        }

        public projectileData GetProjectileData()
        {
            Vector3 direction = GetAimPosition() - transform.position;
            direction.y = 0;
            return new projectileData (weaponConfig.Damage,
                weaponConfig.ArmorPenetrationRate,
                weaponConfig.Range,
                weaponConfig.PrejctileSpeed,
                weaponConfig.ProjectileConfig.CurveIntegrate,
                weaponConfig.ProjectileConfig.SpeedReferance,
                Vector3.Normalize(direction));
        } 
    }
}