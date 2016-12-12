using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace LudumDate37
{
    public class BackToMenu : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FadeMusic.instance.switchToRoom();
                SceneManager.LoadScene("Main");
            }
        }
    }
}