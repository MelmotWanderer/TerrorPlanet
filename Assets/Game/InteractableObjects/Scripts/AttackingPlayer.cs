using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlayer: MonoBehaviour, IInteractable
{
    private PlayerShipContoller _controller;
    
    private void Start() {
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShipContoller>();
        
      
    }

    public void Interact()
    {
        var _hitTransform = _controller.GetHitTransform();
        _controller.SetCurrentTargetForShooting(_hitTransform);
    }
}
