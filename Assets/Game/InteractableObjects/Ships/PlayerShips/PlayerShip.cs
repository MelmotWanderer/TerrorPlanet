using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerShip : Ship
{
    public float Money { get; set; }
    public List<WeaponData> PlayerWeapons;
    public Action<float> OnChangeMoney;
    public Action<string> OnChangeWeapon;
    [SerializeField] private float _money;
    [SerializeField] private Weapon _weapon;

    private void Start()
    {
        Money = _money;
        OnChangeMoney?.Invoke(Money);
        if(_weapon != null)
        {
            _weapon.Init();
        }
        OnChangeWeapon?.Invoke(_weapon.Name);
    }
    public void AddWeapon(WeaponData weaponData)
    {
        PlayerWeapons.Add(weaponData);
        ChangeWeapon(weaponData);
    }
    public void ChangeWeapon(WeaponData weaponData)
    {
        _weapon.SetWeaponData(weaponData);
        _weapon.Init();
        OnChangeWeapon?.Invoke(_weapon.Name);
    } 

    public void AddMoney(float money)
    {
        Money += money;
        OnChangeMoney?.Invoke(Money);
       
    }
    public void RemoveMoney(float money)
    {
        Money -= money;
        OnChangeMoney?.Invoke(Money);
    }
}
