using System;
using UnityEngine;



    public class ActiveZone : MonoBehaviour, IInit<testDelegate>
    {
        private event testDelegate OnTest;
        
        
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IPlayer player))
            {
                OnTest.Invoke(player.GetPosition());
            }
        }

        public void Initialize(testDelegate @delegate)
        {
            OnTest = @delegate;
            @delegate += OnTest;
        }
    }
