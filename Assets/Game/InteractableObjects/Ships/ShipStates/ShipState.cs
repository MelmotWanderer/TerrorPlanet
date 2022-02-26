using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipState: MonoBehaviour
{
    public virtual void Start()
    {
     
    }
    public virtual void Stop()
    {

    }
    public abstract void Run();
    


}
