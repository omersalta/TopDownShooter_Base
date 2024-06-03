using System.Linq;
using UnityEngine;
using ToolBox.Pools;
using Unity.Mathematics;

namespace _Scripts.Player.InventoryItems
{
    public abstract class WeaponBase : MainInventoryItemBase
    {
        private WeaponConfigScriptableObject _defaultWeaponConfig;
        [SerializeField] protected WeaponConfigScriptableObject _weaponConfig;
        protected float lastShootTime;
        
        public void InitializeWeapon(WeaponConfigScriptableObject weaponConfig)
        {
            _defaultWeaponConfig = weaponConfig;
            _weaponConfig = _defaultWeaponConfig;
            foreach (AttachmentBase _attachment in _weaponConfig.currentMountedAttachments)
            {
               
            }
            
        }

        public override void Use(InventoryBase user)
        {
            lastShootTime = lastShootTime = Time.time;
        }

        public virtual GameObject GetProjectileFromPool()
        {
            return _weaponConfig.ProjectileConfig.projectilePrefab.Reuse(transform.position,quaternion.identity);
        }
        
        protected virtual Vector3 GetAimPosition()
        {
            return PlayerInput.PlayerMouseCursor;
        }
        
        public virtual bool isAvailableForAttachment(AttachmentType type){
            bool contains = _weaponConfig.currentMountedAttachments.Any(_pair => _pair._attacmentConfig.type == type);
            return !contains;
        }
        
        public virtual void AddAttachment(AttacmentConfigScriptableObject attacmentConfig)
        {
            _weaponConfig.damage = _defaultWeaponConfig.damage * ((100f + attacmentConfig.damagePercentage)/100);
            _weaponConfig.armorPenetrationRate = _defaultWeaponConfig.armorPenetrationRate * ((100f + attacmentConfig.armorPenetrationRatePercentage)/100);
            _weaponConfig.fireRate = _defaultWeaponConfig.fireRate * ((100f + attacmentConfig.fireRatePercentage)/100);
            _weaponConfig.fireRange = _defaultWeaponConfig.fireRange * ((100f + attacmentConfig.fireRangePercentage)/100);
            _weaponConfig.slightOfHandTime = _defaultWeaponConfig.slightOfHandTime * (attacmentConfig.slightOfHandTimePercentage/100f);
        }
        
        public override void OnTakeInHand()
        {
            lastShootTime = Time.time + _weaponConfig.slightOfHandTime;
            base.OnTakeInHand();
        }
        
        public override void Drop(Vector3 dropPosition)
        {
            foreach (AttachmentBase _attachment in  _weaponConfig.currentMountedAttachments)
            {
                _attachment.Drop(dropPosition);
                dropPosition += dropOffset;
            }
           
            _weaponConfig = _defaultWeaponConfig;
            base.Drop(dropPosition);
        }
    }
}