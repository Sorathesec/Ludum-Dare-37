using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class FadeInWithFear : MonoBehaviour
    {
        // Private variables
        // Code optimisation
        SpriteRenderer theRenderer;

        void Start()
        {
            theRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            int fear = FearController.instance.fearLevel;

            Color newColor = theRenderer.color;

            newColor.a = fear / 100.0f;

            theRenderer.color = newColor;
        }
    }
}