using _Scripts.Inventory_Items;
using _Scripts.Items.CollectableItems;
using UnityEngine;

namespace _Scripts.InventoryItems
{
    public class RocketLauncher : WeaponBase
    {
        public override bool IsAvailableForAttachment(AttachmentType type)
        {
            if (type == AttachmentType.Ammunition || type == AttachmentType.Magazine ||
                type == AttachmentType.Muzzle || type == AttachmentType.Stock)
            {
                FindObjectOfType<UIManager>().SendMessage("Rocket Launchers cannot use diffrent Ammunition or magazine or muzzle or stock ");
                return false;
            }
            
            return base.IsAvailableForAttachment(type);
        }

        public override void Use(InventoryBase user)
        {
            GameObject projectile = GetProjectileFromPool();
            projectile.GetComponent<ProjectileBase>().Setup(CreateProjectileData(user));
            base.Use(user);
        }

        public override void OnPickUpFromGround()
        {
            //nothing
        }
    }
}
