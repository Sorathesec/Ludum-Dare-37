using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class OnTriggerClick : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer rewardImage;

        [SerializeField]
        private SpriteRenderer[] displayImages;

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
        bool canClick = true;

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
            if (canClick && target.CompareTag("Shootable"))
            {
                SpriteRenderer targetSprite = target.gameObject.GetComponent<SpriteRenderer>();

                if (targetSprite != null && target.GetComponent<AudioSource>().enabled)
                { 
                    target.GetComponent<AudioSource>().enabled = false;
                    StartCoroutine(FadeInMarker(targetSprite));
                    circlesHighlighted++;
                    Win();
                    Invoke("ResetClick", 0.5f);
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

                if (!haveValid && target.GetComponent<Animator>() != null)
                {
                    wrongAnimator.enabled = true;
                    target.GetComponent<Animator>().Play("Miss");
                    Wrong.GetComponent<SpriteRenderer>().enabled = true;
                    Invoke("ResetAnimation", 0.755f);

                    if (printOnce < 1)
                    {
                        Miss();
                        printOnce = 2;
                        Invoke("ResetPrintOnce", 1.0f);
                    }
                }
            }
        }

        void ResetClick()
        {
            canClick = true;
        }

        IEnumerator FadeInMarker(SpriteRenderer marker)
        {
            for (int i = 0; i < 50; i++)
            {
                Color newColor = marker.color;
                newColor.a += 0.02f;
                marker.color = newColor;

                yield return new WaitForSeconds(0.02f);
            }
        }

        private void Win()
        {
            canClick = false;
            if (circlesHighlighted >= 5)
            {
                int fearReduction = (int)(fearRemovalValue / diminishingReturns);

                if (fearReduction < 1)
                {
                    fearReduction = 1;
                }
                FearController.instance.RemoveFear(fearReduction);
                diminishingReturns = diminishingReturns / 3;

                StartCoroutine(FadeInSingle());
            }
        }

        IEnumerator FadeInSingle()
        {
            for (int i = 0; i < 100; i++)
            {
                Color newColor = rewardImage.color;
                newColor.a += 0.01f;
                rewardImage.color = newColor;

                yield return new WaitForSeconds(0.01f);
            }
            Invoke("ReturnToMenu", 0.5f);
        }

        IEnumerator FadeOutDouble()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < displayImages.Length; j++)
                {
                    Color newColor = displayImages[j].color;
                    newColor.a -= 0.01f;
                    displayImages[j].color = newColor;
                }
                yield return new WaitForSeconds(0.01f);
            }
            Invoke("ReturnToMenu", 3.0f);
        }

        void ReturnToMenu()
        {
            DisableSpotTheDifference.willDisable = true;
            FadeMusic.instance.switchToRoom();
            SceneManager.LoadScene("Main");
        }

        void Miss()
        {
            canClick = false;
            FearController.instance.AddFear(fearPenaltyValue);
            Invoke("ResetClick", 0.5f);
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