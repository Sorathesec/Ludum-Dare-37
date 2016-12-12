using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class MorphMusic : MonoBehaviour
    {
        AudioSource[] sources;
        private float morphPoint = 0.0f;
        // Use this for initialization
        void Start()
        {
            sources = GetComponents<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            float currentValue = FearController.instance.fearLevel;

            if (currentValue > morphPoint)
            {
                float asPercentage = currentValue / 100.0f;

                sources[0].volume = 1.0f - asPercentage;

                sources[1].volume = asPercentage;
            }
        }
    }
}