using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class BarrelMovement : MonoBehaviour
    {

        Rigidbody2D barrelBody;
        Vector2 barrelMovement;
        public float speed = -5.0f;
        public float x = 1;
        float y = 0;

        // Use this for initialization
        void Start()
        {
            barrelBody = this.GetComponent<Rigidbody2D>();
            Move();
        }

        // Update is called once per frame
        void Update()
        {
            if(x>0.01 && x < 0.95)
            {
                x = 1f;
                Move();
            }
            if (x < -0.01 && x > -0.95)
            {
                x = -1f;
                Move();
            }
           
        }

        void Move()
        {
            Vector2 moveVel = barrelBody.velocity;
            moveVel.x = x * speed;
            barrelBody.velocity = moveVel;
        }
    }
}