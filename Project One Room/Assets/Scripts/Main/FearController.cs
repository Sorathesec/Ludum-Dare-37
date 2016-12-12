using UnityEngine;
using UnityEngine.Audio;
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

        [SerializeField]
        private AudioMixer mixer;

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

            isPlaying = false;
        }

        private void GameOver()
        {
            gameOver = true;
            FadeMusic.instance.switchToNothing();

            isPlaying = false;

            float delay = Random.Range(4.0f, 6.0f);
            Invoke("ShowJumpScare", delay);
        }

        private void ShowJumpScare()
        {
            jumpScare.SetActive(true);
            jumpScare.GetComponent<Animator>().Play("JumpscareAnimation");
            Invoke("ShowLossScreen", 3.0f);
        }

        private void ShowLossScreen()
        {
            lossScreen.SetActive(true);
            jumpScare.GetComponent<Animator>().Stop();
        }

        IEnumerator IncreaseFear()
        {
            while (fearLevel < 100)
            {
                fearLevel++;
                GetComponent<AudioSource>().volume = fearLevel / 2000.0f;
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