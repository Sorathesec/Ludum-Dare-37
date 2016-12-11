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

        private int currentStage = 1;

        // Update is called once per frame
        void Update()
        {
            currentStage = FearController.instance.GetCurrentThreshold();
            
            if(currentStage == 0)
            {
                Stage0();
            }
            else if (currentStage == 1)
            {
                Stage1();
            }
            else if (currentStage == 2)
            {
                Stage2();
            }
            else if (currentStage == 3)
            {
                Stage3();
            }
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