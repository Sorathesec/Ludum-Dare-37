using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

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
                Input.GetKeyDown(KeyCode.E) &&
                FearController.isPlaying)
            {
                GameObject.FindWithTag("Player").GetComponent<MoveCharacter>().enabled = false;

                GameObject.FindWithTag("Player").GetComponent<Animator>().Play("Interact");
                Invoke("SwitchScene", 0.7f);
            }
        }

        private void SwitchScene()
        {
            FadeMusic.instance.switchToGame();

            SceneManager.LoadScene(minigameScene);
        }
    }
}