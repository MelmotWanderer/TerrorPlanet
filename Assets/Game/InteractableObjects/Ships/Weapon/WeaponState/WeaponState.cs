using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponState : MonoBehaviour
{

    public virtual void Start() { }

    public abstract void Run();
    public virtual void Stop() { }
}
