using UnityEngine;
using System.Collections;

public class EnableTriggers : MonoBehaviour {

    public GameObject triggerGroup;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            triggerGroup.SetActive(true);
        }
    }
}
