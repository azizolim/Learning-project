using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController 
{
    private Transform _transform;
    private ActiveZone _activeZone;
    private IInit<testDelegate> _init;
    private testDelegate _testDelegate;
    

    public FaceController(ActiveZone activeZone, Transform transform)
    {
        _activeZone = activeZone;
        _transform = transform;
        _init = _activeZone;
        _testDelegate = Test;
        _init.Initialize(_testDelegate);
    }
    
    private void Test(Vector3 playerPosition)
   {
       Vector3 npcPos = _transform.position;
       Vector3 delta = new Vector3(playerPosition.x - npcPos.x, 0.0f, playerPosition.z - npcPos.z);
       Quaternion rotation = Quaternion.LookRotation(delta);
       _transform.rotation = rotation;
   }
}

public delegate void testDelegate(Vector3 playerPosition);
