using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeaponState: WeaponState
{
    private IStationWeaponStateSwitcher _switcher;
    private Weapon _weapon;
    private float _speedReload;
    public ReloadWeaponState(IStationWeaponStateSwitcher switcher, Weapon weapon)
        {
        _switcher = switcher;
        _weapon = weapon;
         
        }
    public override void Start()
    {
        _speedReload = _weapon.GetSpeedReload();
    }
    public override void Run()
       {
       
        _weapon.ChangeEndurance(_speedReload);
    
        if(_weapon.isEqualMaxEndurance())
        {
            _switcher.SwitchState<NotUsingWeaponState>();
        }
       }
   
}
