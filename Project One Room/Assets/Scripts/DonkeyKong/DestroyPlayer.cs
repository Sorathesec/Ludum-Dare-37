using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class DestroyPlayer : MonoBehaviour
    {

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
            // If the entering collider is the player...
            if (other.gameObject.tag == "Player")
            {
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
}
