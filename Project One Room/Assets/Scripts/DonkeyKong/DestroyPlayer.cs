using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class DestroyPlayer : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            // If the entering collider is the player...
            if (other.gameObject.tag == "Player")
            {
                DKController.instance.RemoveLife();
            }

        }
    }
}
