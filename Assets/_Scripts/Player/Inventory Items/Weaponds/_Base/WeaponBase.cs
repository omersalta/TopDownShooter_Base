using System;
using System.Linq;
using UnityEngine;
using ToolBox.Pools;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.Serialization;

namespace _Scripts.Player.InventoryItems
{
    public abstract class WeaponBase : MainInventoryItemBase
    {
        [SerializeField] protected WeaponConfigScriptableObject defaultWeaponConfig;
        [SerializeField] protected WeaponConfigScriptableObject weaponConfig;
        
        public virtual void InitializeWeapon(WeaponConfigScriptableObject weaponConfig)
        {
            defaultWeaponConfig = weaponConfig;
            this.weaponConfig = Instantiate(weaponConfig);
            foreach (AttachmentBase attachment in this.weaponConfig.CurrentMountedAttachments)
            {
               
            }
            reuseCooldownValueInSeconds = 60 / this.weaponConfig.FireRate;
            lastUseTime = Time.time + this.weaponConfig.SlightOfHandTime;
        }

        public virtual GameObject GetProjectileFromPool()
        {
            return weaponConfig.ProjectileConfig.ProjectilePrefab.Reuse(transform.position,quaternion.identity);
        }
        
        protected virtual Vector3 GetAimPosition()
        {
            return PlayerInput.PlayerMouseCursor;
        }
        
        public virtual bool IsAvailableForAttachment(AttachmentType type){
            //bool contains = WeaponConfig.currentMountedAttachments.Any(pair => pair.AttacmentConfig.type == type);
            //return !contains;
            return true;
        }
        
        public virtual void AddAttachment(AttachmentBase attacment)
        {
            AttacmentConfigScriptableObject config = attacment.AttacmentConfig;
            
            weaponConfig.Damage = defaultWeaponConfig.Damage * ((100f + config.DamagePercentage)/100);
            weaponConfig.ArmorPenetrationRate = defaultWeaponConfig.ArmorPenetrationRate * ((100f + config.ArmorPenetrationRatePercentage)/100);
            weaponConfig.FireRate = defaultWeaponConfig.FireRate * ((100f + config.FireRatePercentage)/100);
            weaponConfig.FireRange = defaultWeaponConfig.FireRange * ((100f + config.FireRangePercentage)/100);
            weaponConfig.SlightOfHandTime = defaultWeaponConfig.SlightOfHandTime * (config.SlightOfHandTimePercentage/100f);
            weaponConfig.CurrentMountedAttachments.Add(attacment);
        }
        
        public override void OnTakeInHand()
        {
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            base.OnTakeInHand();
        }
        
        public override void Drop(Vector3 dropPosition)
        {
            foreach (AttachmentBase attachment in  weaponConfig.CurrentMountedAttachments)
            {
                attachment.Drop(dropPosition);
                dropPosition += dropOffset;
            }
           
            weaponConfig = null;
            base.Drop(dropPosition);
        }
    }
}