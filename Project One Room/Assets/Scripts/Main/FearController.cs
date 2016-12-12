using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LudumDare37
{
    public class FearController : MonoBehaviour
    {
        public static FearController instance;

        public static bool isPlaying = false;

        public int fearLevel = 0;

        [SerializeField]
        private float fearIncreaseDelay = 5;

        [SerializeField]
        private float survivalTimer = 600;

        [SerializeField]
        private GameObject victoryScreen;

        [SerializeField]
        private GameObject lossScreen;

        [SerializeField]
        private GameObject jumpScare;

        private float finishTimer;

        private bool gameOver = false;

        // Use this for initialization
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(instance);

            finishTimer = Time.time + survivalTimer;
        }

        void Update()
        {
            if(!gameOver && Time.time >= finishTimer)
            {
                Victory();
            }
        }

        public void StartGame()
        {
            isPlaying = true;
            StartCoroutine(IncreaseFear());
        }

        private void Victory()
        {
            gameOver = true;
            victoryScreen.SetActive(true);
        }

        private void GameOver()
        {
            gameOver = true;
            jumpScare.SetActive(true);
            Invoke("ShowLossScreen", 3.0f);
        }

        private void ShowLossScreen()
        {
            lossScreen.SetActive(true);
        }

        IEnumerator IncreaseFear()
        {
            while (fearLevel < 100)
            {
                fearLevel++;
                yield return new WaitForSeconds(fearIncreaseDelay);
            }
            if(!gameOver)
            {
                GameOver();
            }
        }

        public void AddFear(int fearAmount)
        {
            fearLevel += fearAmount;
        }

        public void RemoveFear(int fearAmount)
        {
            fearLevel -= fearAmount;
            if(fearLevel < 0)
            {
                fearLevel = 0;
            }
        }
    }
}