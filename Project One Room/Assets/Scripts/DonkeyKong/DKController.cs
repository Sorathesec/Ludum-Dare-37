using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LudumDare37
{
    public class DKController : MonoBehaviour
    {
        // Public variables
        // Static variables
        public static DKController instance;

        private bool playing = false;

        [SerializeField]
        private Text displayText;

        [SerializeField]
        private LivesHandler lives;

        [SerializeField]
        private int fearPenaltyValue = 5;

        [SerializeField]
        private int fearRemovalValue = 10;

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
            StartCoroutine(FadeInText());
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
            StartCoroutine(FadeOutText());
            playing = true;
        }

        public void Victory()
        {
            playing = false;
            int fearReduction = (int)(fearRemovalValue / diminishingReturns);
            if (fearReduction < 1)
            {
                fearReduction = 1;
            }

            FearController.instance.RemoveFear((int)(fearReduction * diminishingReturns));

            diminishingReturns = diminishingReturns / 3 * 2;

            FadeMusic.instance.switchToRoom();
            Application.LoadLevel("Main");
        }

        public void RemoveLife()
        {
            bool result = lives.RemoveLife();

            FearController.instance.AddFear(fearPenaltyValue);

            if (result)
            {
                EndGame();
            }

            ResetEverything();
        }

        public void ResetEverything()
        {
            Transform[] children = GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].GetComponent<AsteroidCreator>() != null ||
                    children[i].GetComponent<DKCharacterMovement>() != null)
                {
                    children[i].SendMessage("Reset");
                }
            }

            GameObject[] destructables = GameObject.FindGameObjectsWithTag("Barrel");

            for (int i = destructables.Length - 1; i > 0; i--)
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