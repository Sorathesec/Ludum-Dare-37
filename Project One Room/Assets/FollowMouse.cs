using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPos.z = 0;

        transform.position = newPos;
	}
}
