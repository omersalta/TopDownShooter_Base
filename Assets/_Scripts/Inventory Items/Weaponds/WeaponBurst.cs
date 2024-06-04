using _Scripts.Extensions;
using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class WeaponBurst : WeaponBase
    {
        protected const float DelayBetweenBurstBullets = 0.04f;
        public override void InitializeWeapon(WeaponConfigScriptableObject config)
        {
            WeaponConfigScriptableObject weaponConfiguration = Instantiate(config);
            weaponConfiguration.FireRate /= 3f;
            base.InitializeWeapon(weaponConfiguration);
        }

        public override void OnPickUpFromGround()
        {
            
        }
        
        public override void Use(InventoryBase user)
        {
            Debug.Log("WeaponBurst... USE");
            
            GameObject bullet1 = GetProjectileFromPool();
            GameObject bullet2 = GetProjectileFromPool();
            GameObject bullet3 = GetProjectileFromPool();

            if (bullet1.GetComponent<ProjectileBase>() == null ||
                bullet2.GetComponent<ProjectileBase>() == null ||
                bullet3.GetComponent<ProjectileBase>() == null)
            {
                Debug.Log("WeaponBurst bullets are not include weaponBase component");
                return;
            }
            
            bullet2.SetActive(false);
            bullet3.SetActive(false);

            /////////////////////BULLET^^^^^^^^^1///////////////////////
            bullet1.GetComponent<ProjectileBase>().Setup(GetProjectileData());
            /////////////////////BULLET^^^^^^^^^2///////////////////////
            Utils.Wait(this, DelayBetweenBurstBullets, () =>
            {
                //repositioning because player moving
                bullet2.SetActive(true);
                bullet2.GetComponent<ProjectileBase>().Setup(GetProjectileData());
                /////////////////////BULLET^^^^^^^^^3///////////////////////
                Utils.Wait(this, DelayBetweenBurstBullets, () =>
                {
                    //repositioning because player moving
                    bullet3.SetActive(true);
                    bullet3.GetComponent<ProjectileBase>().Setup(GetProjectileData());
                });
            });
            base.Use(user);
        }
    }
}