using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class DKCharacterMovement : MonoBehaviour
    {
        public float speed = 10, jumpVelocity = 10;
        public bool canMoveInAir = true;
        Rigidbody2D myBody;
        bool isGrounded = true;
        bool animating = true;
        float y = 0;
        Vector2 movement;
        Vector3 startPos;

        void Start()
        {
            myBody = this.GetComponent<Rigidbody2D>();
            startPos = transform.position;
        }

        void Reset()
        {
            isGrounded = true;
            transform.position = startPos;
            movement = Vector2.zero;
            y = 0;
        }

        void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");

            if (isGrounded)
            {
                if (x == 0)
                {
                    GetComponent<Animator>().Play("Still");
                }
                else
                {
                    GetComponent<Animator>().Play("Walk");
                }
            }

            if(x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            Move(x);
            
            //isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("space key was pressed");
                Jump();
                GetComponent<Animator>().Play("Jump");
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

        public void NoLongerGrounded()
        {
            isGrounded = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "PacmanWall")
            {
                isGrounded = true;
            }
        }
    }
}