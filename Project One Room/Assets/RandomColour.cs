using UnityEngine;
using System.Collections;

public class RandomColour : MonoBehaviour
{
    [SerializeField]
    private Color[] colours;

	void Start ()
    {
        int rnd = Random.Range(0, colours.Length);

        Color chosenColour = colours[rnd];

        GetComponent<SpriteRenderer>().color = chosenColour;
	}
}
