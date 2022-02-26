using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent), typeof(BoxCollider), typeof(Rigidbody))]
public abstract class ShipController: MonoBehaviour
{
    protected NavMeshAgent agent;
    protected List<ShipState> _states;
    protected ShipState _currentState;
    protected Vector3 _currentTarget;
    protected Transform _currentTargetForShooting;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public Vector3 GetCurrentTarget()
    {
      
        return _currentTarget;
    }

    public void SetCurrentTargetForShooting(Transform target)
    {
        _currentTargetForShooting = target;
    }
    public Transform GetCurrentTargetForShooting()
    {
        return _currentTargetForShooting;
    }

    public void SwitchState<T>() where T : ShipState
    {
        var state = _states.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        state.Start();
    }
    protected void SetDefaultState<T>() where T : ShipState
    {
        var state = _states.Find(s => s is T);
        _currentState = state;
        state.Start();
    }

    public void SetCurrentTarget(Vector3 target)
    {
        _currentTarget = target;
    }
   

}
