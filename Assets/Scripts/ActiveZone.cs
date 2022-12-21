using System;
using DefaultNamespace;
using UnityEngine;



    public class ActiveZone : MonoBehaviour, IInit<testDelegate>
    {
        private event testDelegate OnTest;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                OnTest.Invoke(interactable.GetPosition());
            }
        }

        public void Initialize(testDelegate @delegate)
        {
            OnTest = @delegate;
            @delegate += OnTest;
        }
    }
