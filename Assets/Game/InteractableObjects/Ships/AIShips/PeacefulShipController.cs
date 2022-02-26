using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacefulShipController: ShipAIController
{
    
    protected override void Init()
    {
        _move = new MovePeaceful(agent);
    }


    private void Update()
    {
        Move();
    }
}
