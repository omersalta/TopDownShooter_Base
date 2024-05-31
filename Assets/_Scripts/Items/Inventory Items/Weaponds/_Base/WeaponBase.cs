using System.Linq;
using UnityEngine;

namespace _Scripts.Items.InventoryItems
{
    public abstract class WeaponBase : InventoryItemBase
    {
        protected WeaponConfigScriptableObject _weaponConfig;
        protected float lastShootTime;
        
        public abstract void RaycastAction(Collider target);
        public virtual bool isAvailableForAttachment(AttachmentType _type){
            bool contains = _weaponConfig.currentMountedAttachments.Any(_pair => _pair.type == _type);
            return !contains;
        }
        
        public virtual void AddAttachment(AttacmentConfigScriptableObject _attacmentConfig)
        {
            _weaponConfig.damage *= ((100f + _attacmentConfig.damagePercentage)/100);
            _weaponConfig.armorPenetrationRate *= ((100f + _attacmentConfig.armorPenetrationRatePercentage)/100);
            _weaponConfig.fireRate *= ((100f + _attacmentConfig.fireRatePercentage)/100);
            _weaponConfig.fireRange *= ((100f + _attacmentConfig.fireRangePercentage)/100);
            _weaponConfig.slightOfHandTime *= (_attacmentConfig.slightOfHandTimePercentage/100f);
        }
        
    }
}