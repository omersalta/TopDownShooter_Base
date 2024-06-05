using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Extensions;
using _Scripts.Inventory_Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private WeaponConfigScriptableObject _config;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI ArmorPen;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI bulletSpeed;
    public TextMeshProUGUI SlightOfHandTime;
    public TextMeshProUGUI Range;
    public TextMeshProUGUI Message;
    public GameObject MessageField;

    private void Start()
    {
        ShowMessage("'QWER' 'left click' 'g' ");
        Set(null);
    }

    public void Set(WeaponConfigScriptableObject config)
    {
        if (config == null)
        {
            _config = null;
            Name.text = "this section is reserved for seeing the config of weapons";
            Damage.text = "and gives you information when you don't have a weapon in your hand press g to drop weapon";
            ArmorPen.text = "if you drop your weapon, all mounted attachments gonna drop";
            Range.text = "I hope you like it, have fun.";
            fireRate.text = "attachments increase sleight of hand time, so you will have more time to switch between weapons";
            bulletSpeed.text = "you cannot add same attachment type to same weapond";
            SlightOfHandTime.text = "";
        }
        else
        {
            _config = config;
            Name.text = config?.WeaponName;
            Damage.text = config?.Damage.ToString();
            ArmorPen.text = config?.ArmorPenetrationRate.ToString();
            Range.text = config?.Range.ToString();
            fireRate.text = config?.Range.ToString();
            bulletSpeed.text = config?.PrejctileSpeed.ToString();
            SlightOfHandTime.text = config?.SlightOfHandTime.ToString();
        }
        
    }

    public void ShowMessage(string message)
    {
        MessageField.SetActive(true);
        Message.text = message;
        Utils.Wait(this,3.6f, () =>
        {
            MessageField.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
