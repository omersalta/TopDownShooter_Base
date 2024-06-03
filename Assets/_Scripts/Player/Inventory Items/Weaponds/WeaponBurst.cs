using _Scripts.Extensions;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class WeaponBurst : WeaponBase
    {
        protected readonly float delayBetweenBurstBullets = 0.04f;
        
        public override void OnPickUpFromGround()
        {
            throw new System.NotImplementedException();
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
            Vector3 direction;
            direction = GetAimPosition() - bullet1.transform.position;
            bullet1.transform.forward = direction;
            bullet1.GetComponent<ProjectileBase>().Setup(bullet1.transform.forward,2.5f);
            /////////////////////BULLET^^^^^^^^^2///////////////////////
            Utils.Wait(this, delayBetweenBurstBullets, () =>
            {
                //repositioning because player moving
                bullet2.SetActive(true);
                bullet2.transform.position = transform.position;
                direction = GetAimPosition() - bullet2.transform.position;
                bullet2.transform.forward = direction;
                bullet2.GetComponent<ProjectileBase>().Setup(bullet2.transform.forward,2.5f);
                /////////////////////BULLET^^^^^^^^^3///////////////////////
                Utils.Wait(this, delayBetweenBurstBullets, () =>
                {
                    //repositioning because player moving
                    bullet3.SetActive(true);
                    bullet3.transform.position = transform.position; 
                    direction = GetAimPosition() - bullet3.transform.position;
                    bullet3.transform.forward = direction;
                    bullet3.GetComponent<ProjectileBase>().Setup(bullet3.transform.forward,2.5f);
                });
            });
            
            base.Use(user);
        }
    }
}