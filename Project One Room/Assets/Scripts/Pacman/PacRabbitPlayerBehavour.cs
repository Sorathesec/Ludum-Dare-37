using UnityEngine;
using System.Collections;
using System;

namespace LudumDare37
{
    public class PacRabbitPlayerBehavour : MonoBehaviour, Killable
    {
        // Private variables
        // Accessible in the editor
        [SerializeField]
        private float PowerupTimer = 5.0f;

        // Script logic
        private bool canKill = false;
        private Vector3 startPos;

        void Awake()
        {
            startPos = transform.position;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (PacRabbitController.instance.GetPlaying())
            {
                if (other.gameObject.tag == "KillPill")
                {
                    canKill = true;
                    other.gameObject.SetActive(false);

                    Invoke("NoMoreKilling", PowerupTimer);
                }

                if (other.gameObject.tag == "PacRabbitEnemy" &&
                    canKill == true)
                {
                    other.gameObject.SendMessage("Kill");
                }
            }
        }

        private void NoMoreKilling()
        {
            canKill = false;
        }

        public void Revive()
        {
            gameObject.SetActive(true);
        }

        public void Kill()
        {
            if (!canKill)
            {
                PacRabbitController.instance.RemoveLife();
            }
        }

        public GameObject ReturnGameobject()
        {
            return gameObject;
        }

        public void Reset()
        {
            transform.position = startPos;
            GetComponent<GridInputMove>().ResetThis();
        }
    }
}