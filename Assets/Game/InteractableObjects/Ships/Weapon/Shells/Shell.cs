using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float Strength;
    private Vector3 _target;
    private Ship _ship;


    private void Start()
    {
     
        transform.LookAt(_target);
    }
    private void Update()
    {
        MoveShell();
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
             
    }
    public void SetShip(Ship ship)
    {
        _ship = ship;
       
    }
   
    public void SetStrenght(float strenght)
    {
        Strength = strenght;
    }
    protected virtual void MoveShell()
    {
        if (transform.position == _target)
            DestroyShell();
        transform.position = Vector3.MoveTowards(transform.position, _target, 1.0f);
    }


    private void DestroyShell()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent<Ship>() || other.GetComponent<CelestialBody>()) & other.gameObject != _ship.gameObject)
        {

            other.GetComponent<IDamagable>().GetDamage(Strength);
            DestroyShell();
             
        }
                
            
            
    }
    
}
