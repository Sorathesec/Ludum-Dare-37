using UnityEngine;
using System.Collections;
using System;

namespace LudumDare37
{
    public class OpenMinigame : MonoBehaviour
    {
        [SerializeField]
        private string minigameScene;

        private bool canInteract = false;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                canInteract = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                canInteract = false;
            }
        }

        void Update()
        {
            if (canInteract && 
                Input.GetKeyDown(KeyCode.E))
            {
                FadeMusic.instance.switchToGame();

                Application.LoadLevel(minigameScene);
            }
        }
    }
}