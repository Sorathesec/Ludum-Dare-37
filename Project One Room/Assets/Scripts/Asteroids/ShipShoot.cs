using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class ShipShoot : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawn;  //An array of spawn points bullets can spawn from.
        public float FireRate = 0.5f;
        bool isFiring = false;
        
        // Update is called once per frame
        void Fire()
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            isFiring = true;
            Invoke("NoLongerFiring", FireRate);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && isFiring==false)
            {
                Fire();
            }
        }

        void NoLongerFiring()
        {
            isFiring = false;
        }
    }
}