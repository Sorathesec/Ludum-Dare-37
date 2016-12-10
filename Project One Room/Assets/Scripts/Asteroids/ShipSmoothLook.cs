using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class ShipSmoothLook : MonoBehaviour
    {

        public Camera theCamera;
        public float smoothing = 5.0f;
        public float adjustmentAngle = 0.0f;
        public GameObject spriteObject;
        public Transform target;

        void Update()
        {

            Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = target - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);
            spriteObject.transform.rotation = transform.rotation;

        }
    }
}

