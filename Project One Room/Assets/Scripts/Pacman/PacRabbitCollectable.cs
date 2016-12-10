using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class PacRabbitCollectable : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                PacRabbitController.instance.RemoveCount();
                gameObject.SetActive(false);
            }
        }
    }
}