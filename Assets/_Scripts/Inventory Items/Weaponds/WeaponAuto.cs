using System;
using _Scripts.Inventory_Items;
using UnityEngine;

namespace _Scripts.Player.InventoryItems
{
    public class WeaponAuto : WeaponBase
    {
        private bool _isFiring = false;
        private InventoryBase _user;
        public override void Use(InventoryBase user)
        {
            Debug.Log("WeaponSemiAuto... USE");
            GameObject bullet = GetProjectileFromPool();
            bullet.GetComponent<ProjectileBase>().Setup(GetProjectileData());
            base.Use(user);
        }

        private void Update()
        {
            if (_isFiring && lastUseTime + reuseCooldownValueInSeconds <= Time.time)
            {
                Use(_user);
            }
        }

        public override void MouseDown(InventoryBase user)
        {
            _user = user;
            _isFiring = true;
            if (_isFiring && lastUseTime + reuseCooldownValueInSeconds <= Time.time)
            {
                Use(_user);
            }
        }
        public override void MouseUp(InventoryBase user)
        {
            _isFiring = false;
        }
        
        public override void OnPickUpFromGround()
        {
            //nothing
        }
    }
}