using System;
using _Scripts.Inventory_Items;
using _Scripts.InventoryItems;
using _Scripts.ShootMechanic.Health_System;
using _Scripts.ShootMechanic.Health_System._Base;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooter : InventoryBase
{
    [Range(0.5f,2f)]
    [SerializeField] private float _aimingAccuracy;
    
    [Range(0.1f,2)]
    [SerializeField] private float _shootingDelayRandom;
    
    private float _lastShootTime;
    [SerializeField] private WeaponAuto weapon;
    [SerializeField] private WeaponConfigScriptableObject config;
    [SerializeField] private Transform _body;
    private void Awake()
    {
        _myTeam = Team.Red;
        if (config != null)
        {
            weapon.InitializeWeapon(config,null);
        }else {
            weapon.InitializeWeaponAsDefault();
        }
        
    }
    void Shoot(Vector3 target)
    {
        float x, y, z;
        x = Random.Range(-_aimingAccuracy,_aimingAccuracy);
        y = Random.Range(-_aimingAccuracy,_aimingAccuracy);
        z = Random.Range(-_aimingAccuracy,_aimingAccuracy);
        
        weapon.UseForBot(this,target+new Vector3(x,y,z));
    }


    private void OnTriggerStay(Collider other)
    {
        ShootableCharacter target = other.GetComponent<ShootableCharacter>();

        if (target != null && target.GetTeam() == Team.Blue)
        {
            _body.LookAt(other.transform.position);
            if (_lastShootTime < Time.time )
            {
                _lastShootTime = Time.time + Random.Range(0.1f,_shootingDelayRandom);
                Shoot(other.transform.position);
            }
        }
    }
    public override bool IsInventoryAvailable()
    {
        return false;
    }
    public override bool IsInventoryAvailableForNonUsable()
    {
        return false;
    }
}
