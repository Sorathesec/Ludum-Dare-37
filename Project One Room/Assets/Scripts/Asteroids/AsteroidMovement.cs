using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class AsteroidMovement : MonoBehaviour
    {

        public float speed = 5.0f;
        public float destroyTime = 1.5f;
        bool left = false;
        bool right = false;
        bool top = false;
        bool bottom = false;

        void Start()
        {
            Invoke("Die", destroyTime);
            speed = Random.Range(0.5f, 1.5f);
            CalculatePosition();
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

        void CalculatePosition()
        {

        }
    }
}
