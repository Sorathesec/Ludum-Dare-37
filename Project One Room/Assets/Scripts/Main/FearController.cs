using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

namespace LudumDare37
{
    public class FearController : MonoBehaviour
    {
        // Public variables
        // Static variables
        public static FearController instance;
        public static bool isPlaying = false;

        // To be accessed by other scripts
        [HideInInspector]
        public int fearLevel = 0;

        // Private variables
        // Accessible in the editor
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

        // Script logic
        private float finishTimer;
        private bool gameOver = false;

        // Code optimisation
        private AudioSource theAudioScource;

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

            theAudioScource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if(isPlaying && 
                !gameOver && 
                Time.time >= finishTimer)
            {
                Victory();
            }
        }

        public void StartGame()
        {
            isPlaying = true;
            finishTimer = Time.time + survivalTimer;
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
                theAudioScource.volume = fearLevel / 2000.0f;
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