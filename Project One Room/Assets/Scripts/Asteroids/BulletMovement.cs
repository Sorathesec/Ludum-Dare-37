using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class BulletMovement : MonoBehaviour
    {

        public float speed = 5.0f;
        public float destroyTime = 1.5f;

        void Start()
        {
            Invoke("Die", destroyTime);
        }

        void Die()
        {
            Destroy(gameObject);
        }

        void OnDestroy()
        {
            CancelInvoke("Die");
        }

        void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
    }
}