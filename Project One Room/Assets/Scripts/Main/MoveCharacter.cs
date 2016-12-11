﻿using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private float minY = -5.0f;
    [SerializeField]
    private float maxY = 5.0f;
    [SerializeField]
    private float minScale = 0.5f;
    [SerializeField]
    private float maxScale = 1.5f;

    private static Vector3 position;
    private Animator theAnimator;

    void Awake()
    {
        theAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(x == 0 && y == 0)
        {
            theAnimator.Play("Still");
        }
        else
        {
            theAnimator.Play("Walk");
        }

        move2D(x, y);
    }

    void move2D(float x, float y)
    {
        Vector2 direc = new Vector2(x, y);

        Vector2 newPos = (Vector2)transform.position + direc;

        transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime * moveSpeed);

        if (transform.position.y < minY)
        {
            Vector2 pos = new Vector2(transform.position.x, minY);
            transform.position = pos;
        }
        if (transform.position.y > maxY)
        {
            Vector2 pos = new Vector2(transform.position.x, maxY);
            transform.position = pos;
        }

        float yRange = Mathf.Abs(maxY - minY);

        float onePerc = yRange / 100;

        float currentY = transform.position.y - minY;

        float percValue = currentY / onePerc;

        float scaleRange = Mathf.Abs(maxScale -minScale);

        float scaOnePerc = scaleRange / 100;

        float newScaleValue = maxScale - (scaOnePerc * percValue);

        Vector3 newScale = transform.localScale;
        if(x > 0)
        {
            newScale = new Vector3(-newScaleValue, newScaleValue, newScaleValue);
        }
        else if(x < 0)
        {
            newScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
        }
        
        transform.localScale = newScale;
    }
}
