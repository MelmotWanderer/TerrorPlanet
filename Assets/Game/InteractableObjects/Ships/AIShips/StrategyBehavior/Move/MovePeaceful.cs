using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovePeaceful : IMove
{
    private NavMeshAgent agent;
    private Vector3 target;
    public MovePeaceful(NavMeshAgent _agent)
    {
        agent = _agent;
    }
    public void Move()
    {
        if(target == Vector3.zero || Vector3.Distance(target, agent.transform.position) < 50.0f)
        {
            target = new Vector3(Random.Range(1, 700), 1, Random.Range(1, 700));
        }
        
        agent.SetDestination(target);
    }
  
   
}
