using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeaponState: WeaponState
{
    private IStationWeaponStateSwitcher _switcher;
    private Weapon _weapon;
    private float _delay;
    private float _currentDelay;
    private Ship _ship;
    public ShootingWeaponState(IStationWeaponStateSwitcher switcher, Weapon weapon)
        {
    
        _switcher = switcher;
        _weapon = weapon;
       
        _ship = _weapon.GetShip();

        }

    public override void Start()
        {
        _delay = _weapon.GetDelay();
        _currentDelay = _delay;
        }
    public override void Run()
    {
      
        if (_weapon.GetTarget() != Vector3.zero)
        {
            if (_weapon.GetEndurance() == 0.0f || Input.GetKey(KeyCode.R))
            {
                _switcher.SwitchState<ReloadWeaponState>();
            }
            _currentDelay -= Time.deltaTime;

            if (_currentDelay < 0)
            {

                _weapon.ChangeEndurance(-25.5f);
                CreateShell();
                _currentDelay = _delay;
            }
        }else
        {
            _switcher.SwitchState<NotUsingWeaponState>();
        }
        
       
    }
    public override void Stop()
        {
        
        }

 

    private void CreateShell()
        {
       
        var shell = Instantiate(_weapon.Shell, _weapon.transform.position, Quaternion.identity);
        
        shell.SetShip(_weapon.GetShip());
        shell.SetTarget(_weapon.GetTarget());
        shell.SetStrenght(_weapon.GetStrenght());
        
        }
   
}
