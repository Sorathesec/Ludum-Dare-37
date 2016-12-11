using UnityEngine;
using System.Collections;

public class MoveBarrels : MonoBehaviour
{
    [SerializeField]
    private bool left = false;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Barrel")
        {
            Rigidbody2D temp = other.GetComponent<Rigidbody2D>();
            if(left)
            {
                if(temp.velocity.x > -2)
                {
                    temp.velocity = new Vector2(temp.velocity.x - 0.1f, temp.velocity.y);
                }
            }
            else
            {
                if (temp.velocity.x < 2)
                {
                    temp.velocity = new Vector2(temp.velocity.x + 0.1f, temp.velocity.y);
                }
            }
        }
    }
}
