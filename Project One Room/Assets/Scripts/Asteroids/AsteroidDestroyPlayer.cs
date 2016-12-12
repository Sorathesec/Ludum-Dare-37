using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class AsteroidDestroyPlayer : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            // If the entering collider is the player...
            if (other.gameObject.tag == "Player")
            {
                AsteroidController.instance.RemoveLife();
                other.gameObject.GetComponent<ShipController>().Reset();
            }
        }
    }
}