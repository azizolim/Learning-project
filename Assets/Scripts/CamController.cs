using System.Collections;
using System.Collections.Generic;
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
                _playerMovement.Invoke(hit.point);
            }
        }
    }


    public void Initialize(movementDelegate @delegate)
    {
        _playerMovement = @delegate;
        @delegate += _playerMovement;
    }
}
