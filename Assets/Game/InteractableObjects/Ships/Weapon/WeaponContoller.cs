using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponContoller : MonoBehaviour, IStationWeaponStateSwitcher
{

    private WeaponState _currentState;

    private List<WeaponState> _allStates;

    private Weapon _weapon;

  
    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        _allStates = new List<WeaponState>()
        {
            new NotUsingWeaponState(this, _weapon),
            new ShootingWeaponState(this, _weapon),    
            new ReloadWeaponState(this, _weapon)
        };

        SetDefaultState<NotUsingWeaponState>();
    }

    void Update()
    {
        _currentState.Run();
    }
    public void SetTargetForShoot(Vector3 target)
    {
        _weapon.SetTarget(target);
        
     
    }
   public void StopShoot()
    {
        _weapon.SetTarget(Vector3.zero);
        
    }
    public void SwitchState<T>() where T: WeaponState
    {
        var state = _allStates.Find(s => s is T);
        _currentState.Stop();      
        _currentState = state;
        state.Start();
    }
    public void SetDefaultState<T>() where T: WeaponState
    {
        var state = _allStates.Find(s => s is T);
        _currentState = state;
        state.Start();

    }
    
  
}
