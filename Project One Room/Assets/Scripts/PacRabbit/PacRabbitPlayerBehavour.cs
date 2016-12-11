using UnityEngine;
using System.Collections;
using System;
using Netaphous.Utilities;

namespace LudumDare37
{
    public class PacRabbitPlayerBehavour : MonoBehaviour, Killable
    {
        // Private variables
        // Accessible in the editor
        [SerializeField]
        private float PowerupTimer = 5.0f;
        [SerializeField]
        private int fearLossFromKill = 3;

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

                    EventManager.TriggerEvent("EnemiesKillable");
                }

                if (other.gameObject.tag == "PacRabbitEnemy" &&
                    canKill == true)
                {
                    other.gameObject.SendMessage("Kill");
                    FearController.instance.RemoveFear(fearLossFromKill);
                }
            }
        }

        private void NoMoreKilling()
        {
            canKill = false;
            EventManager.TriggerEvent("EnemiesSafe");
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
                GetComponent<GridInputMove>().theAnimator.enabled = false;
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