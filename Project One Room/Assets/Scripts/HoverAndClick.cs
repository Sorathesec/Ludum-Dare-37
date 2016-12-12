using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class HoverAndClick : MonoBehaviour
    {
        [SerializeField]
        private GameObject glow;

        private bool interactable = false;

        void OnEnable()
        {
            if(FearController.isPlaying)
            {
                ActivateGame();
            }
        }

        void Update()
        {
            if (interactable && Input.GetMouseButtonDown(0))
            {
                ActivateGame();
                FearController.instance.StartGame();
            }
        }

        private void ActivateGame()
        {
            gameObject.SetActive(false);
            GameObject.FindWithTag("Player").SetActive(true);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "MousePointer")
            {
                glow.SetActive(true);
                interactable = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "MousePointer")
            {
                glow.SetActive(false);
                interactable = false;
            }
        }
    }
}