using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class ShipAIController: ShipController
{
  
    protected IMove _move;
    protected IFire _fire;
    

    private void Start()
    {
       
        Init();
    }


    public void Move()
    {
        _move.Move();
    }
    
    protected abstract void Init();

    

}
