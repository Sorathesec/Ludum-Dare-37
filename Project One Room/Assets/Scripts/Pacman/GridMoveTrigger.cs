using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LudumDare37
{
    public class GridMoveTrigger : MonoBehaviour
    {
        // Public variables
        // To be accessed by other scripts
        public bool isColliding;

        // Private variables
        // Script logic
        private List<Collider2D> otherColliders;

        void Awake()
        {
            otherColliders = new List<Collider2D>();
        }

        void FixedUpdate()
        {
            if (otherColliders.Count > 0)
            {
                isColliding = true;
            }
            else
            {
                isColliding = false;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Collectable" &&
                other.tag != "KillPill")
            {
                otherColliders.Add(other);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag != "Collectable" &&
                other.tag != "KillPill")
            {
                otherColliders.Remove(other);
            }
        }
    }
}