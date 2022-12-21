using System;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;

        private void Update()
        {
            if (Input.GetButtonDown("Fire2")) 
            {
               Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}