using UnityEngine;
using System.Collections;
using Netaphous.Utilities;

namespace LudumDare37
{
    public class RestartGame : MonoBehaviour
    {
        private bool interactable = false;

        void Update()
        {
            if (interactable && Input.GetMouseButtonDown(0))
            {
                Restart();
            }
        }

        private void Restart()
        {
            GameObject[] objects = FindObjectsOfType<GameObject>();
            foreach (GameObject o in objects)
            {
                if(o != Camera.main.gameObject)
                {
                    Destroy(o.gameObject);
                }
            }
            FearController.isPlaying = false;

            LoadScene.LoadLevel("Main");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "MousePointer")
            {
                interactable = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "MousePointer")
            {
                interactable = false;
            }
        }
    }
}