using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CamController : MonoBehaviour, IInit<movementDelegate>
{
    [SerializeField] private Camera myCamera;
    private event movementDelegate _playerMovement;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                 _playerMovement.Invoke(interactable.GetPosition());   
                }
                else
                {
                    _playerMovement.Invoke(hit.point);
                }
            }
        }
    }

    public void Initialize(movementDelegate @delegate)
    {
        _playerMovement = @delegate;
        @delegate += _playerMovement;
    }
}
