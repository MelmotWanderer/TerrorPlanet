using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipContoller : ShipController, IStateShipSwitcher
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private WeaponContoller _wpcontoller;
    private bool _isShopping = false;
    
    private RaycastHit _hit;
    
    private void Start()
    {
        _states = new List<ShipState>()
        {
            new IdleState(),
            new MovingState(this, agent),
            new ShootingShipState(this, agent, _wpcontoller),
          
        };
        
        SetDefaultState<IdleState>();
       
    }
    private void Update()
    {
        if (!_isShopping)
        {
            if (!isInteract())
            {

                _currentState.Run();
            }
        }
       
            

    }
    private bool isInteract()
    {
        if (Input.GetButtonDown("Interact"))
        {
            var _ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out RaycastHit hit))
            {
                _hit = hit;

                 if(_hit.transform.GetComponent(typeof(IInteractable)) as IInteractable != null)
                  {
                    _hit.transform.GetComponent<IInteractable>().Interact();
                  }else
                {
                    SetCurrentTargetForShooting(null); 
                }

                SetCurrentTarget(_hit.point);
                SwitchState<MovingState>();
            }
            return true;
        }
        return false;
    }
  

    public Transform GetHitTransform()
    {
        return _hit.transform;
    }
    public void SetShopping(bool isShopping)
    {
        _isShopping = isShopping;
    }

    public bool GetShopping()
    {
        return _isShopping;
    }




}
