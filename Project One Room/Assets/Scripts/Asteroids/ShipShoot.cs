using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class ShipShoot : MonoBehaviour
    {

        public GameObject bulletPrefab;
        public Transform bulletSpawn;  //An array of spawn points bullets can spawn from.
        public float fireTime = 0.2f;
        public AudioClip shootClip;

        private bool isFiring = false;

        void SetFiring()
        {
            isFiring = false;
        }

        // Update is called once per frame
        void Fire()
        {
            isFiring = true;
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            Invoke("SetFiring", fireTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
        }
    }
}
