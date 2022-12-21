using System;
using DefaultNamespace;
using UnityEngine;

    public class Enemy : MonoBehaviour, IInteractable
    {
        [SerializeField] private ActiveZone activeZone;
        private void Start()
        {
            var faceController = new FaceController(activeZone, transform);
        }

        public Vector3 GetPosition()
        {
         var position=   new Vector3(transform.position.x, 0,
                transform.position.z);
         return position;
        }

        public void Damage()
        {
            
        }
    }
