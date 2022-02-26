using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStationWeaponStateSwitcher 
{
    void SwitchState<T>() where T : WeaponState;
}
