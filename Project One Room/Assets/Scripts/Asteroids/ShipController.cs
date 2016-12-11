using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    public float speed = 5.0f;
    Vector2 movement;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate processes physics every frame
    //x and y get values from wasd keys for movement
    //this is then used to calculate players velocity which is times by public speed so its easier to manipulate in unity
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Move(x, y);

    }

    void Move(float x, float y)
    {
        movement.Set(x, y);
        //movement = movement.normalized;
        rigidbody2D.velocity = movement * speed;
        rigidbody2D.angularVelocity = 0.0f;
    }
}
