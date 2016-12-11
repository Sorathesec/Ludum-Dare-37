using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class HoverAndClick : MonoBehaviour
    {
        [SerializeField]
        private GameObject glow;

        private bool interactable = false;

        void Update()
        {
            if (interactable && Input.GetMouseButtonDown(0))
            {
                gameObject.SetActive(false);
                GameObject.FindWithTag("Player").GetComponent<MoveCharacter>().enabled = true;
                FearController.instance.StartGame();
            }
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