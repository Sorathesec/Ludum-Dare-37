using UnityEngine;
using System.Collections;

public class PlayerInside : MonoBehaviour
{
    public bool inside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = false;
        }
    }
}
