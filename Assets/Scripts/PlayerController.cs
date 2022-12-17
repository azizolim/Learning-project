using System;
using System.Collections;
using System.Collections.Generic;using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CamController camController;
    
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
public delegate Vector3 playerPosDelegate();


public interface IPlayer
{
    public Vector3 GetPosition();
}