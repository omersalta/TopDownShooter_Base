using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    public Vector3 RespawnPosition;
    public GameObject Player;
    private void Awake()
    {
        Player.transform.position = transform.position;
    }
    public void Respawn()
    {
        Player.SetActive(false);
        
        Utils.Wait(this, 2f, () =>
        {
            Player.SetActive(true);
            GetComponentInChildren<ShootableCharacter>().Heal(100);
            GetComponentInChildren<ShootableCharacter>().ArmorUp(100);
            Player.transform.position = RespawnPosition;
        });
        
       
       
    }
}
