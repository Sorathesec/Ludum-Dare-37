using UnityEngine;
using System.Collections;

public class AsteroidTakeDamage : MonoBehaviour {

    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shootable"))
        {
            print("astroid shot");
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }

}
