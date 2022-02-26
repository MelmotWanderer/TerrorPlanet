using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class CelestialBody : MonoBehaviour, IDamagable
{
    public float Health { get; set; }
    protected float Size { get; set; }
    protected float SpeedRotation { get; set; }


    public Action<float> OnGetDamage { get; set; }
    public Action<float> OnDeath { get; set; }


    [SerializeField] private float AwardForKill;



    private void Awake()
    {
       SetEnergy();
       SetSize();
       SetSpeedRotation();
       transform.localScale = new Vector3(Size, Size, Size);
     

    }

    public void GetDamage(float damage)
    {


        Health -=  damage;
        OnGetDamage?.Invoke(Health);
        if (Health <= 0.0f)
        {
            OnDeath.Invoke(AwardForKill);
            Destroy(gameObject);
        }

    }
    public float GetSize()
    {
        return Size;
    }
    private void SetEnergy()
    {
        Health =  UnityEngine.Random.Range(50, 190);
    }
    private void SetSize()
    {
        Size = Health * 0.18f;
    }
    
    private void SetSpeedRotation()
    {
        SpeedRotation = UnityEngine.Random.Range(0, 0.4f);
    }
  
    
  
   
}
