using System;
using System.Collections;
using System.Collections.Generic;using System.Threading;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IInteractable
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CamController camController;
    [SerializeField] private ActiveZone activeZone;
    private FaceController _faceController;

    private void Start()
    {
        _faceController = new FaceController(activeZone, transform);
    }

    public Vector3 GetPosition() => transform.position;
    private movementDelegate _movementDelegate;
    private IInit<movementDelegate> _camInit;

    private void Awake()
    {
        _movementDelegate = Movement;
        _camInit = camController;
        _camInit.Initialize(_movementDelegate);

    }

    private void Movement(Vector3 point )
    {
        agent.SetDestination(point);
    }
}

public delegate void movementDelegate(Vector3 point);
