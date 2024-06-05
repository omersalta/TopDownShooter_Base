using System.Collections.Generic;
using System.Linq;
using _Scripts.Player;
using _Scripts.ShootMechanic.Health_System;
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
        
        public virtual void InitializeWeapon(WeaponConfigScriptableObject Config,GameObject collected)
        {
            dropSpawnGameObject = collected;
            this.defaultWeaponConfig = Config;
            weaponConfig = Instantiate(defaultWeaponConfig);
            reuseCooldownValueInSeconds = 60 / weaponConfig.FireRate;
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            currentMountedAttachments.Clear();
        }
        
        public void InitializeWeaponAsDefault()
        {
            weaponConfig = Instantiate(defaultWeaponConfig);
            reuseCooldownValueInSeconds = 60 / weaponConfig.FireRate;
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            currentMountedAttachments.Clear();
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
            
            bool contains = currentMountedAttachments.Any(pair => pair.Key == type);
            FindObjectOfType<UIManager>().ShowMessage("the weapon already has" + type.ToString());
            return !contains;
        }
        
        public virtual void AddAttachment(AttachmentBase attacment)
        {
            AttacmentConfigScriptableObject config = attacment.AttacmentConfig;
            weaponConfig.Damage += config.Damage;
            float newPenValue = weaponConfig.ArmorPenetrationRate + config.ArmorPenetration;
            weaponConfig.ArmorPenetrationRate = Mathf.Clamp(newPenValue,0f,100f);
            weaponConfig.FireRate += defaultWeaponConfig.FireRate * (100f + config.FireRatePercentage)/100;
            weaponConfig.Range += config.FireRange;
            weaponConfig.SlightOfHandTime += defaultWeaponConfig.SlightOfHandTime + (defaultWeaponConfig.SlightOfHandTime * (config.SlightOfHandTimePercentage/100f));
            currentMountedAttachments.Add(config.Type,attacment);
            FindObjectOfType<UIManager>().ShowMessage("Attachment added " + attacment.AttacmentConfig.AttachmentName);
            FindObjectOfType<UIManager>().Set(weaponConfig);
        }
        
        public override void OnTakeInHand()
        {
            FindObjectOfType<UIManager>().Set(weaponConfig);
            lastUseTime = Time.time + weaponConfig.SlightOfHandTime;
            base.OnTakeInHand();
        }
        
        public override void DropAndDestroy()
        {
            base.DropAndDestroy();
        }

        public projectileData CreateProjectileData(InventoryBase user)
        {
            Vector3 direction = GetAimPosition() - transform.position;
            direction.y = 0;
            
            return new projectileData (weaponConfig.Damage,
                weaponConfig.ArmorPenetrationRate,
                weaponConfig.Range,
                weaponConfig.PrejctileSpeed,
                weaponConfig.ProjectileConfig.CurveIntegrate,
                weaponConfig.ProjectileConfig.SpeedReferance,
                Vector3.Normalize(direction),
                user.GetTeam());
        }
        
        public projectileData CreateProjectileDataForBot(InventoryBase user, Vector3 target)
        {
            projectileData data = CreateProjectileData(user);
            data.ShootDirection = Vector3.Normalize(target - transform.position);
            return data;
        } 
    }
}