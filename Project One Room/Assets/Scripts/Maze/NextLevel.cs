using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public GameObject nextLevel;
    public GameObject nextTriggerGroup;
    public GameObject previousLevel;
    public GameObject previousTriggerGroup;
    public GameObject nextEnd;
    public GameObject previousEnd;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            if (nextTriggerGroup != null)
            {
                nextTriggerGroup.SetActive(true);
            }
            if (nextLevel != null)
            {
                nextLevel.SetActive(true);
            }
            if (nextEnd != null)
            {
                nextEnd.SetActive(true);
            }
            if (previousTriggerGroup != null)
            {
                previousTriggerGroup.SetActive(false);
            }
            if (previousLevel != null)
            {
                previousLevel.SetActive(false);
            }
            if (previousEnd != null)
            {
                previousEnd.SetActive(false);
            }
        }
    }
}
