using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ActiveZone activeZone;
    private IInit<testDelegate> _init;
    private testDelegate _testDelegate;

    private void Start()
    {
        _testDelegate = Test;
        _init = activeZone;
        _init.Initialize(_testDelegate);
        
    }

    void Update()
    {
       
    }
   
   
   private void Test(Vector3 playerPosition)
   {
       Debug.Log("hello");
       Vector3 npcPos = transform.position;
       Vector3 delta = new Vector3(playerPosition.x - npcPos.x, 0.0f, playerPosition.z - npcPos.z);
       Quaternion rotation = Quaternion.LookRotation(delta);
       transform.rotation = rotation;
   }
}

public delegate void testDelegate(Vector3 playerPosition);
