using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class MazeController : MonoBehaviour
    {
        // Public variables
        // Static variables
        public static MazeController instance;

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

        public void Victory()
        {
            int fearReduction = (int)(fearRemovalValue / diminishingReturns);
            if (fearReduction < 1)
            {
                fearReduction = 1;
            }

            FearController.instance.RemoveFear(fearReduction);

            diminishingReturns = diminishingReturns / 3 * 2;

            FadeMusic.instance.switchToRoom();
            SceneManager.LoadScene("Main");
        }

        private void EndGame()
        {
            FearController.instance.AddFear(fearPenaltyValue);

            FadeMusic.instance.switchToRoom();

            SceneManager.LoadScene("Main");
        }
    }
}