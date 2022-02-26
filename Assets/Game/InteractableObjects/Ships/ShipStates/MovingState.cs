using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovingState : ShipState
{
    private Vector3 _currentTarget;
    private NavMeshAgent _agent;
    private PlayerShipContoller _controller;
    private float distance;

    public MovingState(PlayerShipContoller controller,NavMeshAgent agent)
    {
        _agent = agent;
        _controller = controller;

    }

    public override void Start()
    {
      _currentTarget = _controller.GetCurrentTarget();
        if (_controller.GetCurrentTargetForShooting() != null)
        {
            distance = 50.0f;
        }
        else
        {
            distance = 1.0f;
        }

    }
    public override void Run()
    {
    
        
        
      if(Vector3.Distance(_currentTarget, _controller.transform.position) > distance)
        {
            _agent.SetDestination(_currentTarget);
            
        }
        else
        {
            _agent.ResetPath();
            if (_controller.GetCurrentTargetForShooting() != null)
            {
                _controller.SwitchState<ShootingShipState>();
            }
            else
            {
                _controller.SwitchState<IdleState>();
            }
        }
            

        
       
        
    
    }
}
