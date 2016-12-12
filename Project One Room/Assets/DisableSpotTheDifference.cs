using UnityEngine;
using System.Collections;

public class DisableSpotTheDifference : MonoBehaviour
{
    public static bool willDisable = false;

    void Start()
    {
        if(willDisable)
        {
            gameObject.SetActive(false);
        }
    }
}
