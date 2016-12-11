using UnityEngine;
using System.Collections;
using System;

namespace LudumDare37
{
    public class OpenMinigame : MonoBehaviour
    {
        [SerializeField]
        private string minigameScene;

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" &&
                Input.GetKeyDown(KeyCode.E))
            {
                Application.LoadLevel(minigameScene);

            }
        }
    }
}