using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingShipContoller : ShipAIController
{
    [SerializeField] private Transform _player;
    [SerializeField] private Weapon _weapon;
    private Transform target;
    void Start()
    {
 
        target = _player;
    }

   
    void Update()
    {
       if(target != null)
        {
            _weapon.SetTarget(target.position);
        } 
    }
    protected override  void Init()
    {

    }

}
