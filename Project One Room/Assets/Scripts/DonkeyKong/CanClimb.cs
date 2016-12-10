using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class CanClimb : MonoBehaviour
    {

        private Collider2D LadderRangeCollider;
        public Collider2D BlockCollider1;
        Collider2D BarrelCollider;
        bool playerInRange;
        bool barrelInRange;
        float x = 0;
        public float speed = 2.0f;
        Vector2 movement;
        float barrelVelocity;
        Rigidbody2D rigidbody2D;
        public Rigidbody2D barrelbody2D;
        public GameObject character;
        float randomNumber = 100.0f;
        public GameObject barrelObject;
        int i = 0;
        int a = 0;
        float barrelSpeed = 1;
        Vector2 theVelocity;
        float distToGround;
        public bool onlyReverseDirection;
        public bool onlyEffectsBarrels;


        // Use this for initialization
        void Start()
        {
            if (character != null)
            {
                rigidbody2D = character.GetComponent<Rigidbody2D>();
            }

            LadderRangeCollider = this.GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (BlockCollider1 != null && character != null)
            {
                if (playerInRange == true && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
                {
                    float y = Input.GetAxis("Vertical");
                    movement.Set(x, y);
                    rigidbody2D.velocity = movement * speed;
                    BlockCollider1.enabled = false;
                    rigidbody2D.GetComponent<Rigidbody2D>().gravityScale = 0;
                    rigidbody2D.GetComponent<Rigidbody2D>().drag = 10;
                }

                if (playerInRange == true && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
                {
                    float y = Input.GetAxis("Vertical");
                    movement.Set(x, y);
                    rigidbody2D.velocity = -movement * -speed;
                    BlockCollider1.enabled = false;
                }

            }

            if (onlyEffectsBarrels == true)
            {

                if (barrelInRange == true && onlyReverseDirection == true)
                {
                    BlockCollider1.enabled = false;

                    if (i < 1)
                    {

                        theVelocity = barrelObject.GetComponent<Rigidbody2D>().velocity;
                        barrelVelocity = -barrelObject.GetComponent<BarrelMovement>().x;
                        theVelocity = new Vector2(1.5f * barrelVelocity, theVelocity.y);
                        barrelObject.GetComponent<BarrelMovement>().x = barrelVelocity;
                        Invoke("ReverseVelocity", 0.2f);
                        i++;
                    }



                }

                else if (barrelInRange == true && randomNumber <= 33.0f)
                {
                    BlockCollider1.enabled = false;

                    if (i < 1)
                    {

                        theVelocity = barrelObject.GetComponent<Rigidbody2D>().velocity;
                        barrelVelocity = -barrelObject.GetComponent<BarrelMovement>().x;
                        theVelocity = new Vector2(1.5f * barrelVelocity, theVelocity.y);
                        barrelObject.GetComponent<BarrelMovement>().x = barrelVelocity;
                        Invoke("NoVelocity", 0.25f);
                        Invoke("ReverseVelocity", 0.75f);
                        i++;
                    }
                }
            }
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            // If the entering collider is the player...
            if (other.gameObject.tag == "Player")
            {
                // ... the player is in range.
                playerInRange = true;
            }

            // If the entering collider is a barrel...
            if (other.gameObject.tag == "Barrel")
            {
                // ... the barrel is in range.
                barrelInRange = true;
                if (onlyReverseDirection == true)
                {
                    Invoke("OnlyReverseVelocity", 0.1f);
                }
                randomNumber = Random.Range(0.0f, 100.0f);
                barrelObject = other.gameObject;
            }

        }

        void ReverseVelocity()
        {
            barrelObject.GetComponent<Rigidbody2D>().velocity = theVelocity;
        }

        void OnlyReverseVelocity()
        {
            theVelocity = barrelObject.GetComponent<Rigidbody2D>().velocity;
            barrelVelocity = -barrelObject.GetComponent<BarrelMovement>().x;
            theVelocity = new Vector2(1.5f * barrelVelocity, theVelocity.y);
            barrelObject.GetComponent<BarrelMovement>().x = barrelVelocity;
            barrelObject.GetComponent<Rigidbody2D>().velocity = theVelocity;
        }

        void NoVelocity()
        {
            Vector2 noVelocity = new Vector2(0.0f, 0.0f);
            barrelObject.GetComponent<Rigidbody2D>().velocity = noVelocity;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            // If the exiting collider is the player...
            if (other.gameObject.tag == "Player")
            {
                // ... the player is no longer in range.
                playerInRange = false;
                if (BlockCollider1 != null)
                {
                    BlockCollider1.enabled = true;
                }
                other.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
                other.GetComponent<Rigidbody2D>().drag = 0;
            }

            // If the exiting collider is a barrel...
            if (other.gameObject.tag == "Barrel")
            {
                // ... the barrel is no longer in range.
                barrelInRange = false;
                if (BlockCollider1 != null)
                {
                    BlockCollider1.enabled = true;
                }
                i = 0;
            }
        }

    }
}
