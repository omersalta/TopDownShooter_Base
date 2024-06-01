using System.Linq;
using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public abstract class WeaponBase : DropableItemBase
    {
        protected WeaponConfigScriptableObject _defaultWeaponConfig;
        protected WeaponConfigScriptableObject _weaponConfig;
        protected float lastShootTime;
        
        public virtual void Initialize(WeaponConfigScriptableObject weaponConfig, GameObject spawnPrefab)
        {
            _defaultWeaponConfig = weaponConfig;
            _weaponConfig = weaponConfig;
            _weaponConfig.currentMountedAttachments.ForEach(x => AddAttachment(x.attacmentConfig));
            _inventorySprite = _weaponConfig.inventorySprite;
            _dropSpawnPrefab = spawnPrefab;
        }
        
        public virtual bool isAvailableForAttachment(AttachmentType type){
            bool contains = _weaponConfig.currentMountedAttachments.Any(_pair => _pair.type == type);
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
        
    }
}