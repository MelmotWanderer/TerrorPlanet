using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
public class SpaceStation : MonoBehaviour
{
    public List<WeaponData> _weaponDatas;
    public PlayerShip _playerShip;
    public bool isNoneWeapon;
    public Action<bool> OnNoneWeapon;

    private void Start()
    {
        _playerShip = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShip>();
       
    }

   

    public void PurchaseWeapon(WeaponProduct weaponProducts)
    {
        _weaponDatas.Remove(weaponProducts._weaponData);
        _playerShip.AddWeapon(weaponProducts._weaponData);
        _playerShip.RemoveMoney(weaponProducts._weaponData.Price);
        if(_weaponDatas.Count == 0)
        {
            isNoneWeapon = true;
            OnNoneWeapon?.Invoke(true);
        }
    }
    public WeaponData[] GetWeaponDatas()
    {
       
        return _weaponDatas.ToArray();
    }

    public void SetPlayerIsShopping(bool isShopping)
    {
         _playerShip.GetComponent<PlayerShipContoller>().SetShopping(isShopping);
    }

}
