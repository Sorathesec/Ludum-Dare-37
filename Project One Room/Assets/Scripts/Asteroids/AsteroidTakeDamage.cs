using UnityEngine;
using System.Collections;

public class AsteroidTakeDamage : MonoBehaviour {

    public int damage = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shootable"))
        {
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }

}
