using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float _speedRotation = 0;
    private void FixedUpdate()
    {
        Rotate();
    }

    public void SetSpeedRotation(float speed)
    {
       
        _speedRotation = speed;
    }
    private void Rotate()
    {
        transform.Rotate(0.0f, 10.0f * _speedRotation, 0.0f);
    }

    
}
