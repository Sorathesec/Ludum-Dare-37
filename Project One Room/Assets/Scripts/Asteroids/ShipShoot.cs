using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class ShipShoot : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawn;  //An array of spawn points bullets can spawn from.
        
        // Update is called once per frame
        void Fire()
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
    }
}