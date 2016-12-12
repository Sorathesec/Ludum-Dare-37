using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class PacRabbitController : MonoBehaviour
    {
        // Public variables
        // Static variables
        public static PacRabbitController instance;

        // Private variables
        // Accessible in the editor
        [SerializeField]
        private LivesHandler lives;
        [SerializeField]
        private Text displayText;
        [SerializeField]
        private int fearPenaltyValue = 5;
        [SerializeField]
        private int fearReductionValue = 20;
        [SerializeField]
        private int carrotsForBonus = 20;

        // Script logic
        private List<GameObject> collectables;
        private int count;
        private bool completed = false;
        private List<GameObject> killables;
        private bool playing = false;
        private static float diminishingReturns = 1.0f;
        private int bonusCounter = 0;
        
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }

            collectables = new List<GameObject>();
            killables = new List<GameObject>();
        }

        void Start()
        {
            PacRabbitCollectable[] temp = GetComponentsInChildren<PacRabbitCollectable>();

            for (int i = 0; i < temp.Length; i++)
            {
                collectables.Add(temp[i].gameObject);
            }

            Killable[] temp2 = GetComponentsInChildren<Killable>();


            for (int i = 0; i < temp2.Length; i++)
            {
                killables.Add(temp2[i].ReturnGameobject());
            }

            Reset();
        }

        void OnEnable()
        {
            if(completed)
            {
                Reset();
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
            Invoke("StartPlaying", 1);
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

        private void Reset()
        {
            for (int i = 0; i < collectables.Count; i++)
            {
                collectables[i].SetActive(true);
            }
            for (int i = 0; i < killables.Count; i++)
            {
                killables[i].SendMessage("Revive");
            }
            count = collectables.Count;
            completed = false;

            StartCoroutine(FadeInText());
        }

        public void SoftReset()
        {
            for (int i = 0; i < killables.Count; i++)
            {
                killables[i].SendMessage("Reset");
            }
            Invoke("StartPlaying", 2.0f);
        }

        public bool GetPlaying()
        {
            return playing;
        }

        private void StartPlaying()
        {
            playing = true;
            StartCoroutine(FadeOutText());
        }

        public void RemoveLife()
        {
            bool result = lives.RemoveLife();

            FearController.instance.AddFear(fearPenaltyValue);

            if(result)
            {
                EndGame();
            }

            playing = false;
            SoftReset();
        }

        private void EndGame()
        {
            FearController.instance.AddFear(fearPenaltyValue);
            FadeMusic.instance.switchToRoom();
            SceneManager.LoadScene("Main");
        }

        public void RemoveCount()
        {
            count--;

            bonusCounter++;

            if(bonusCounter >= carrotsForBonus)
            {
                FearController.instance.RemoveFear(1);
                bonusCounter -= carrotsForBonus;
            }

            if(count <= 0)
            {
                Victory();
            }
        }

        private void Victory()
        {
            completed = true;
            FearController.instance.RemoveFear((int)(fearReductionValue * diminishingReturns));

            diminishingReturns = diminishingReturns / 3.0f * 2.0f;

            FadeMusic.instance.switchToRoom();

            SceneManager.LoadScene("Main");
        }

        public int GetCount()
        {
            return count;
        }
    }
}