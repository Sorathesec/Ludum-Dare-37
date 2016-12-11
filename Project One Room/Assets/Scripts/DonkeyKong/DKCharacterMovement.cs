using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class DKCharacterMovement : MonoBehaviour
    {

        public float speed = 10, jumpVelocity = 10;
        public LayerMask playerMask;
        public bool canMoveInAir = true;
        Transform myTrans, tagGround;
        Rigidbody2D myBody;
        bool isGrounded = true;
        float hInput = 0;
        float y = 0;
        Vector2 movement;

        void Start()
        {
            myBody = this.GetComponent<Rigidbody2D>();
            myTrans = this.transform;
            
        }

        void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            Move(x);
            
            //isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("space key was pressed");
                Jump();
            }
        }

        void Move(float x)
        {
            if (!canMoveInAir && !isGrounded)
                return;

            Vector2 moveVel = myBody.velocity;
            moveVel.x = x * speed;
            myBody.velocity = moveVel;
        }

        void Movement(float x)
        {
            movement.Set(x, y);
            //movement = movement.normalized;
            myBody.velocity = movement * speed;
            myBody.angularVelocity = 0.0f;
        }

        public void Jump()
        {
            if (isGrounded == true)
            {
                print("jump");
                myBody.velocity += jumpVelocity * Vector2.up;
                NoLongerGrounded();
            }
        }

        public void StartMoving(float horizonalInput)
        {
            hInput = horizonalInput;
        }

        public void NoLongerGrounded()
        {
            isGrounded = false;
            Invoke("Grounded", 0.8f);
        }

        public void Grounded()
        {
            isGrounded = true;
        }
    }
}
