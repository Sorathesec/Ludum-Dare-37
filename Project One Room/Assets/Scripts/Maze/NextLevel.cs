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
            if (nextLevel)
            {
                nextLevel.SetActive(true);
            }
            if (nextEnd)
            {
                nextEnd.SetActive(true);
            }
            
            previousTriggerGroup.SetActive(false);
            previousLevel.SetActive(false);
            previousEnd.SetActive(false);
        }
    }
}
