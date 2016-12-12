using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace LudumDare37
{
    public class DetectMouse : MonoBehaviour
    {
        void Update()
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.CompareTag("Shootable"))
            {
                Destroy(gameObject);
                GameOver();
            }
        }

        void GameOver()
        {
            SceneManager.LoadScene("MazeGame");
        }
    }
}