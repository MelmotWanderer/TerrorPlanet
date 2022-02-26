using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Ship : MonoBehaviour, IDamagable
{
    public float Health { get; set; }
    public Action<float> OnGetDamage { get; set; }
    public Action<float> OnDeath { get; set; }

    [SerializeField] [Min(1)] private float _health;
    [SerializeField] private float AwardForKill;
    

    private void Awake()
    {
        Health = _health;        
    }
    public void GetDamage(float damage)
    {
       
        Health -= damage;
        OnGetDamage?.Invoke(Health);
        if (Health <= 0.0f)
        {
            OnDeath?.Invoke(AwardForKill);
            Destroy(gameObject);
        }
        
       
    }
    
}
