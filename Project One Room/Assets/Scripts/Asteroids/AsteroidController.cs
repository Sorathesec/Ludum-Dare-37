using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LudumDare37
{
    public class AsteroidController : MonoBehaviour
    {
        // Public variables
        // Static variables
        public static AsteroidController instance;

        private bool playing = false;

        [SerializeField]
        private float timerLength = 2.0f;

        [SerializeField]
        private Text displayText;

        [SerializeField]
        private LivesHandler lives;

        [SerializeField]
        private int fearPenaltyValue = 5;

        [SerializeField]
        private int fearRemovalValue = 10;

        private float startTime;

        private float finishtime;

        private static float diminishingReturns = 1.0f;


        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        void OnEnable()
        {
            displayText.text = "Survive for " + timerLength + " seconds!";

            StartCoroutine(FadeInText());
        }

        // Update is called once per frame
        void Update()
        {
            if (playing && Time.time > finishtime)
            {
                Victory();
            }
        }

        IEnumerator FadeInText()
        {
            for (int i = 0; i < 20; i++)
            {
                Color newColor = displayText.color;
                newColor.a += 0.1f;
                displayText.color = newColor;
                yield return new WaitForSeconds(0.05f);
            }
            Invoke("StartTimer", 1);
        }

        IEnumerator FadeOutText()
        {
            for (int i = 0; i < 20; i++)
            {
                Color newColor = displayText.color;
                newColor.a -= 0.1f;
                displayText.color = newColor;
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void StartTimer()
        {
            startTime = Time.time;
            finishtime = startTime + timerLength;
            StartCoroutine(FadeOutText());
            playing = true;
        }

        private void Victory()
        {
            playing = false;
            int fearReduction = (int) (fearRemovalValue / diminishingReturns);
            if(fearReduction < 1)
            {
                fearReduction = 1;
            }

            FearController.instance.RemoveFear(fearReduction);

            diminishingReturns = diminishingReturns / 3 * 2;

            FadeMusic.instance.switchToRoom();
            Application.LoadLevel("Main");
        }

        public void RemoveLife()
        {
            bool result = lives.RemoveLife();

            if (result)
            {
                EndGame();
            }

            ResetEverything();
        }

        public void ResetEverything()
        {
            Transform[] children = GetComponentsInChildren<Transform>();

            for(int i = 0; i < children.Length; i++)
            {
                if(children[i].GetComponent<AsteroidCreator>() != null ||
                    children[i].GetComponent<ShipController>() != null)
                {
                    children[i].SendMessage("Reset");

                }
            }

            GameObject[] destructables = GameObject.FindGameObjectsWithTag("Shootable");

            for(int i = destructables.Length - 1; i > 0; i--)
            {
                Destroy(destructables[i]);
            }
        }

        private void EndGame()
        {
            FearController.instance.AddFear(fearPenaltyValue);

            FadeMusic.instance.switchToRoom();
            Application.LoadLevel("Main");
        }
    }
}