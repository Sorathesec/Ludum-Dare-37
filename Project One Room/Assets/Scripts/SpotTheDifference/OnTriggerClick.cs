using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class OnTriggerClick : MonoBehaviour
    {
        [SerializeField]
        private int fearPenaltyValue = 3;

        [SerializeField]
        private int fearRemovalValue = 20;

        private static float diminishingReturns = 1.0f;

        int circlesHighlighted = 0;
        Collider2D target;
        public GameObject Wrong;
        Animator wrongAnimator;
        List<Collider2D> colliders = new List<Collider2D>();
        [SerializeField]
        private SpriteRenderer errorImage;
        int printOnce = 0;

        void Start()
        {
            wrongAnimator = Wrong.GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        void OnTriggerEnter2D(Collider2D target)
        {
            colliders.Add(target);
        }

        void OnTriggerExit2D(Collider2D target)
        {
            colliders.Remove(target);
        }

        void OnTriggerStay2D(Collider2D target)
        {

            if (target.CompareTag("Shootable"))
            {
                if (target.GetComponent<Animator>() != null && target.GetComponent<Animator>().enabled != true)
                {
                    target.GetComponent<Animator>().enabled = true;
                    circlesHighlighted++;
                    Win();
                }

            }
            else
            {
                bool haveValid = false;
                for (int i = 0; i < colliders.Count; i++)
                {
                    if (colliders[i].tag == "Shootable")
                    {
                        haveValid = true;
                    }
                }

                if (!haveValid)
                {
                    if (target.GetComponent<Animator>() != null)
                    {

                        wrongAnimator.enabled = true;
                        target.GetComponent<Animator>().Play("Miss");
                        Wrong.GetComponent<SpriteRenderer>().enabled = true;
                        Invoke("ResetAnimation", 0.755f);

                        if (printOnce < 1)
                        {
                            print("Miss");
                            Miss();
                            printOnce = 2;
                            Invoke("ResetPrintOnce", 1.0f);
                        }

                    }
                }
            }
        }
        
        void Win()
        {
            if (circlesHighlighted >= 5)
            {
                int fearReduction = (int)(fearRemovalValue / diminishingReturns);
                if (fearReduction < 1)
                {
                    fearReduction = 1;
                }

                FearController.instance.RemoveFear(fearReduction);

                diminishingReturns = diminishingReturns / 3;

                FadeMusic.instance.switchToRoom();
                SceneManager.LoadScene("Main");

                Invoke("ReturnToMenu", 1.0f);
            }
        }

        void ReturnToMenu()
        {
            FadeMusic.instance.switchToRoom();

            SceneManager.LoadScene("Main");
        }

        void Miss()
        {
            FearController.instance.AddFear(fearPenaltyValue);
        }

        void ResetAnimation()
        {
            wrongAnimator.enabled = false;
            Wrong.GetComponent<SpriteRenderer>().enabled = false;
        }

        void ResetPrintOnce()
        {
            printOnce = 0;
        }
    }
}