using UnityEngine;
using System.Collections;

public class OnTriggerClick : MonoBehaviour {

    public GameObject circleHighlights;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        print("click recieved");
        target.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Reveal()
    {
        circleHighlights.SetActive(true);
    }

}
