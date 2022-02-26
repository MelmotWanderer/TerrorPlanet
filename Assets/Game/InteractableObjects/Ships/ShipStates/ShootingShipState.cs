using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShootingShipState: ShipState
{



    private ShipController _controller;
    private NavMeshAgent _agent;
    private Transform _target;
    private WeaponContoller _weaponContoller;

    public ShootingShipState(ShipController controller, NavMeshAgent agent, WeaponContoller weaponContoller)
    {
        _controller = controller;
        _weaponContoller = weaponContoller;
        _agent = agent;
       
    }


    public override void Start() 
    {
        
        _target = _controller.GetCurrentTargetForShooting();

        _target.GetComponent<IDamagable>().OnDeath += _controller.GetComponent<PlayerShip>().AddMoney;
    } 
    public override void Run()
    {
       
       
        if (_target != null)
        {
            if(Vector3.Distance(_target.position, _controller.transform.position) > 60.0f)
            {
                _controller.SetCurrentTarget(_target.position);
                _controller.SwitchState<MovingState>();
            }
            else
            {
                _controller.transform.LookAt(_target);
                _weaponContoller.SetTargetForShoot(_target.position);
            }
           
           
        }else
        {
            _weaponContoller.StopShoot();
            _controller.SwitchState<IdleState>();
        }
       
    }

    public override void Stop()
    {
      
        _weaponContoller.StopShoot();
    }
}
