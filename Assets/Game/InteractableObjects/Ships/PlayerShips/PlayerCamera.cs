using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera CameraControl;
    [SerializeField] private float _maxY; 
    [SerializeField] private float _minY; 
    [SerializeField] private float _maxZ; 
    [SerializeField] private float _minZ;
    private float currentY;
    private float currentZ;

    private void Start()
    {
       
    }
    private void Update()
    {

        Zoom();
        

    }

    private void Zoom()
    {
        currentY = CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;
        currentZ = CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z;
        if (Input.GetAxis("Zoom") > 0)
        {
         if(_minY < currentY & Mathf.Abs(_minZ) < Mathf.Abs(currentZ))
            {
                CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y -= 2.0f;
                CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z += 2.0f;
            }
                
        }
        else if (Input.GetAxis("Zoom") < 0)
        {
            if (_maxY > currentY & Mathf.Abs(_maxZ) > Mathf.Abs(currentZ))
            {
                CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y += 2.0f;
                CameraControl.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z -= 2.0f;
            }
        }
    }
}
