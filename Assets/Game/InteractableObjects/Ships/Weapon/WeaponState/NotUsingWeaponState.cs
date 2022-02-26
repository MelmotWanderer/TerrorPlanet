using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotUsingWeaponState : WeaponState
{
    private Weapon _weapon;
    private IStationWeaponStateSwitcher _switcher;
    public NotUsingWeaponState(IStationWeaponStateSwitcher switcher ,Weapon weapon)
    {
        _weapon = weapon;
        _switcher = switcher;
    }

    public override void Run()
    {
      
        if (_weapon.GetTarget() != null)
        {
            _switcher.SwitchState<ShootingWeaponState>();
        }
        if (Input.GetKey(KeyCode.R))
        {
            _switcher.SwitchState<ReloadWeaponState>();
        }
    }
   
}
