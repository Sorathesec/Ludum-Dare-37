using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        private int maxLives = 3;

        // Script logic
        private List<GameObject> collectables;
        private int count;
        private bool completed = false;
        private int lives = 3;
        private List<GameObject> killables;
        private bool playing = false;
        
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

            lives = maxLives;
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

        void Reset()
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
            Invoke("StartPlaying", 2.0f);
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
        }

        public void RemoveLife()
        {
            lives--;
            if(lives <= 0)
            {
                EndGame();
            }
            playing = false;
            SoftReset();
        }

        private void EndGame()
        {

        }

        public void RemoveCount()
        {
            count--;
            if(count <= 0)
            {
                completed = true;
                print("Win");
            }
        }

        public int GetCount()
        {
            return count;
        }

        void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 300, 40), "PacRabbit Count left: " + count);
            GUI.Label(new Rect(20, 40, 300, 40), "PacRabbit Lives left: " + lives);
        }
    }
}