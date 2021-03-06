﻿using UnityEngine;
using System.Collections;
using Netaphous.Utilities;

namespace LudumDare37
{
    public class PacRabbitAIBehaviour : MonoBehaviour, Killable
    {
        [SerializeField]
        private float moveSpeed = 0.5f;
        Vector3 startPos;

        private bool isDead = false;

        private float topSpeed;

        // Use this for initialization
        void Awake()
        {
            startPos = transform.position;
        }

        void OnEnable()
        {
            EventManager.StartListening("EnemiesKillable", Killable);
            EventManager.StartListening("EnemiesSafe", Safe);
        }

        void Onisable()
        {
            EventManager.StopListening("EnemiesKillable", Killable);
            EventManager.StopListening("EnemiesSafe", Safe);
        }

        void Update()
        {
            if(PacRabbitController.instance.GetPlaying() && isDead)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * moveSpeed);    // Move there
                if(transform.position == startPos)
                {
                    Revive();
                }
            }
        }

        void Killable()
        {
            GetComponent<GridAIMove>().animating = false;

            GetComponent<GridAIMove>().theAnimator.Play("Killable");
            topSpeed = GetComponent<GridAIMove>().moveSpeed;
            GetComponent<GridAIMove>().moveSpeed = topSpeed / 4 * 3;
        }

        void Safe()
        {
            GetComponent<GridAIMove>().animating = true;

            GetComponent<GridAIMove>().moveSpeed = topSpeed;
        }

        public void Kill()
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<GridAIMove>().running = false;

            isDead = true;

            GetComponent<GridAIMove>().theAnimator.Play("Dead");
        }

        public void Revive()
        {
            GetComponent<Collider2D>().enabled = true;

            isDead = false;

            transform.position = startPos;

            Invoke("Activate", 0.2f);
        }

        private void Activate()
        {
            GetComponent<GridAIMove>().ResetThis();
            GetComponent<GridAIMove>().TryMove();
            GetComponent<GridAIMove>().running = true;
        }

        public GameObject ReturnGameobject()
        {
            return gameObject;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            print(other.gameObject.tag);
            if (other.gameObject.tag == "Player" && !isDead)
            {
                print("Kill");
                other.gameObject.GetComponent<PacRabbitPlayerBehavour>().Kill();
            }
        }

        public void Reset()
        {
            transform.position = startPos;

            Revive();

            GetComponent<GridAIMove>().ResetThis();
        }
    }
}