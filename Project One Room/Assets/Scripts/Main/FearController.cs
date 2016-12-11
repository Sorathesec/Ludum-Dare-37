using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class FearController : MonoBehaviour
    {
        public static FearController instance;

        public int fearLevel = 0;

        public int stage1Threshold;
        public int stage2Threshold;
        public int stage3Threshold;

        [SerializeField]
        private float fearIncreaseDelay = 5;

        // Use this for initialization
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

            DontDestroyOnLoad(instance);

            StartCoroutine(IncreaseFear());
        }

        IEnumerator IncreaseFear()
        {
            while (fearLevel < 100)
            {
                fearLevel++;
                yield return new WaitForSeconds(fearIncreaseDelay);
            }
        }

        public void IncreaseFearSpeed(float speedIncrease)
        {
            fearIncreaseDelay -= speedIncrease;
        }

        public void ReduceFearSpeed(float speedDecrease)
        {
            fearIncreaseDelay += speedDecrease;
        }

        public void AddFear(int fearAmount)
        {
            fearLevel += fearAmount;
        }

        public void RemoveFear(int fearAmount)
        {
            fearLevel -= fearAmount;
        }

        public int GetCurrentThreshold()
        {
            if (fearLevel < stage1Threshold)
            {
                return 0;
            }
            else if (fearLevel < stage2Threshold)
            {
                return 1;
            }
            else if (fearLevel < stage3Threshold)
            {
                return 2;
            }
            else if(fearLevel <= 100)
            {
                return 3;
            }
            return -1;
        }
    }
}