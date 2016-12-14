using UnityEngine; 
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class BackToMenu : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && FearController.isPlaying)
            {
                FadeMusic.instance.switchToRoom();
                SceneManager.LoadScene("Main");
            }
        }
    }
}