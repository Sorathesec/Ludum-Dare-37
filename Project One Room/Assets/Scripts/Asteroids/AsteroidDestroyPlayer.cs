using UnityEngine;
using System.Collections;

public class AsteroidDestroyPlayer : MonoBehaviour {


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            print("hello");
            // If the entering collider is the player...
            if (other.gameObject.tag == "Player")
            {
                print("hell");
                // ... the player is in range.
                Destroy(other);
                GameOver();
            }

        }

        void GameOver()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
}
