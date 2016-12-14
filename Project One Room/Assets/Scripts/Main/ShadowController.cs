using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class ShadowController : MonoBehaviour
    {
        // Private variables
        // Accessible in the editor
        [SerializeField]
        private SpriteRenderer[] stages;

        // Script logic
        private int currentStage = 1;

        // Code optimisation
        SpriteRenderer aStage;
        Color newColor;
        FearController inst;

        void Start()
        {
            inst = FearController.instance;
        }

        // Update is called once per frame
        void Update()
        {
            float currentFear = inst.fearLevel;

            if (currentFear < 100)
            {
                if (currentFear > (100 / 7) * currentStage)
                {
                    currentStage++;
                }

                if (currentStage < stages.Length)
                {
                    aStage = stages[currentStage - 1];
                    newColor = aStage.color;

                    float irrelevantFear = (100 / 7) * (currentStage - 1);
                    float relevantFear = currentFear - irrelevantFear;
                    float thresholdPerc = 100 / 7;
                    float percValue = relevantFear / thresholdPerc;

                    newColor.a = percValue;
                    aStage.color = newColor;
                }
            }
        }
    }
}