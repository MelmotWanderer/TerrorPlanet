using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpaceStationUI))]
public class ShopForPlayer : MonoBehaviour, IInteractable
{

    private SpaceStationUI _spaceStation;
 
    private void Start()
    {
        _spaceStation = GetComponent<SpaceStationUI>();
    


    }

    public void Interact()
    {
        _spaceStation.CreateWeaponProducts();
        _spaceStation.ShowUI();
       


    }
}
