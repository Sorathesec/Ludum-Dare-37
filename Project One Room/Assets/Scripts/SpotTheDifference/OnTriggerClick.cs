using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTriggerClick : MonoBehaviour {

    int circlesHighlighted = 0;
    Collider2D target;
    public GameObject Wrong;
    Animator wrongAnimator;
    List<Collider2D> colliders = new List<Collider2D>();
    [SerializeField]
    private SpriteRenderer errorImage;
    int printOnce=0;

    void Start()
    {
        wrongAnimator = Wrong.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        colliders.Add(target);
    }

    void OnTriggerExit2D(Collider2D target)
    {
        colliders.Remove(target);
    }

    void OnTriggerStay2D(Collider2D target)
    {

        if (target.CompareTag("Shootable"))
        {
            if (target.GetComponent<Animator>() != null && target.GetComponent<Animator>().enabled != true)
            {
                //target.GetComponent<Animator>().Play("Markers");
                target.GetComponent<Animator>().enabled = true;
                circlesHighlighted++;
                Win();
            }

        }
        else
        {
            bool haveValid = false;
            for (int i = 0; i < colliders.Count; i++)
            {
                if (colliders[i].tag == "Shootable")
                {
                    haveValid = true;
                }
            }

            if(!haveValid)
            {
                //StartCoroutine(FlashError());
                if (target.GetComponent<Animator>() != null)
                {
                    
                    wrongAnimator.enabled=true;
                    target.GetComponent<Animator>().Play("Miss");
                    Wrong.GetComponent<SpriteRenderer>().enabled = true;
                    Invoke("ResetAnimation", 0.755f);

                    if (printOnce < 1)
                    {
                        print("Miss");
                        Miss();
                        printOnce = 2;
                        Invoke("ResetPrintOnce", 1.0f);
                    }
                    
                }
            }
        }
    }

    /*IEnumerator FlashError()
    {
        for (int i = 0; i < 10; i++)
        {
            Color newColour = errorImage.color;
            newColour.a += 0.01f;
            errorImage.color = newColour;
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(HideError());
    }

    IEnumerator HideError()
    {
        for (int i = 0; i < 10; i++)
        {
            Color newColour = errorImage.color;
            newColour.a -= 0.01f;
            print(newColour.a);
            errorImage.color = newColour;
            yield return new WaitForSeconds(0.01f);
        }
    }*/

    void Win()
    {
        if (circlesHighlighted >= 5)
        {
            print("win");
        }
    }

    void Miss()
    {
        //fear meter rises
        print("fear increase");
    }

    void ResetAnimation()
    {
        wrongAnimator.enabled = false;
        Wrong.GetComponent<SpriteRenderer>().enabled = false;
    }

    void ResetPrintOnce()
    {
        printOnce = 0;
    }


}
