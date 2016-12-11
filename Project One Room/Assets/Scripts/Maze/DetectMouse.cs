using UnityEngine;
using System.Collections;

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
        Application.LoadLevel(Application.loadedLevel);
    }

}
