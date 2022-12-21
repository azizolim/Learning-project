using System;
using UnityEngine;



    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private Rigidbody bulletRigidbody;

        private void Start()
        {
            bulletRigidbody.velocity = transform.forward * bulletSpeed;
        }


        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
