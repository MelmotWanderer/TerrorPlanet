using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateShipSwitcher 
{
    void SwitchState<T>() where T : ShipState;
}
