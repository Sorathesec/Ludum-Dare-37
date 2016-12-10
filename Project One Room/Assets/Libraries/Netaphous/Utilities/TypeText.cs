using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Netaphous.Utilities
{
    public class TypeText : MonoBehaviour
    {
        // Private variables
        // Accessible in the editor
        [SerializeField]
        private float typeDelay = 0.1f;
        [SerializeField]
        private Text textBox;
        [SerializeField]
        private GameObject displayPanel;

        // Script logic
        private string currentString = "";
        private string targetString = "";

        public void HidePopup()
        {
            displayPanel.SetActive(false);
        }

        public void StartTypePerLetter(string textToType)
        {
            currentString = "";
            targetString = textToType;

            displayPanel.SetActive(true);

            StartCoroutine("TypePerLetter");
        }

        IEnumerator TypePerLetter()
        {
            for (int i = 0; i < targetString.Length; i++)
            {
                currentString += targetString[i];

                textBox.text = currentString;

                yield return new WaitForSeconds(typeDelay);
            }
        }
    }
}