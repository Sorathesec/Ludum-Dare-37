using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class ShadowController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer stage1;
        [SerializeField]
        private SpriteRenderer stage2;
        [SerializeField]
        private SpriteRenderer stage3;
        [SerializeField]
        private SpriteRenderer stage4;
        [SerializeField]
        private SpriteRenderer stage5;
        [SerializeField]
        private SpriteRenderer stage6;
        [SerializeField]
        private SpriteRenderer stage7;

        private int currentStage = 1;

        private SpriteRenderer[] stages;
        SpriteRenderer aStage;
        Color newColor;

        void Start()
        {
            stages = new SpriteRenderer[7];

            stages[0] = stage1;
            stages[1] = stage2;
            stages[2] = stage3;
            stages[3] = stage4;
            stages[4] = stage5;
            stages[5] = stage6;
            stages[6] = stage7;
        }

        // Update is called once per frame
        void Update()
        {
            float currentFear = FearController.instance.fearLevel;
            if (currentFear < 100 && currentFear > (100 / 7) * currentStage)
            {
                currentStage++;
            }
            
            aStage = stages[currentStage - 1];
            newColor = aStage.color;
            float irrelevantFear = (100 / 7) * (currentStage - 1);
            float relevantFear = currentFear - irrelevantFear;

            float thresholdPerc = 100 / 7;

            float percValue = relevantFear / thresholdPerc;

            newColor.a = percValue;
            aStage.color = newColor;

            /*
            if (currentStage <= 0)
            {
                Stage0();
            }
            else if (currentStage <= 1)
            {
                Stage1();
            }
            else if (currentStage <= 2)
            {
                Stage2();
            }
            else if (currentStage <= 3)
            {
                Stage3();
            }*/
        }

        private void Stage0()
        {
            int threshold = FearController.instance.stage1Threshold;

            float thresholdPerc = threshold / 100.0f;

            int currentFear = FearController.instance.fearLevel;

            float percValue = currentFear / thresholdPerc;

            Color newColour = stage1.color;
            newColour.a = percValue / 100;

            stage1.color = newColour;
        }

        private void Stage1()
        {
            int threshold = FearController.instance.stage2Threshold;

            float thresholdPerc = (threshold - FearController.instance.stage1Threshold) / 100.0f;

            int currentFear = FearController.instance.fearLevel - FearController.instance.stage1Threshold;

            float percValue = currentFear / thresholdPerc;

            Color newColour = stage2.color;
            newColour.a = percValue / 100;

            stage2.color = newColour;

        }

        private void Stage2()
        {
            int threshold = FearController.instance.stage3Threshold;

            float thresholdPerc = (threshold - FearController.instance.stage2Threshold) / 100.0f;

            int currentFear = FearController.instance.fearLevel - FearController.instance.stage2Threshold;

            float percValue = currentFear / thresholdPerc;

            Color newColour = stage3.color;
            newColour.a = percValue / 100;

            stage3.color = newColour;

        }

        private void Stage3()
        {
            int threshold = 100;

            float thresholdPerc = (threshold - FearController.instance.stage3Threshold) / 100.0f;

            int currentFear = FearController.instance.fearLevel - FearController.instance.stage3Threshold;

            float percValue = currentFear / thresholdPerc;

            Color newColour = stage4.color;
            newColour.a = percValue / 100;

            stage4.color = newColour;
        }
    }
}