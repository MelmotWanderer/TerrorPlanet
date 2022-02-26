using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IDamagable
{

    public float Health { get; set; }
    public void GetDamage(float damage);
    public  Action<float> OnGetDamage { get; set; }
    public Action<float> OnDeath { get; set; }
}
