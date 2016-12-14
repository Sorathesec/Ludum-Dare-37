using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class MoveCharacter : MonoBehaviour
    {
        // Private variables
        // Accessible in the editor
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

        // Code optimisation
        private static Vector3 position;
        private Animator theAnimator;
        private SpriteRenderer theRenderer;
        private Vector2 direc;
        private Vector2 newPos;
        private Vector2 pos;

        void Awake()
        {
            theAnimator = GetComponent<Animator>();
            theRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x == 0 && y == 0)
            {
                theAnimator.Play("Still");
            }
            else
            {
                theAnimator.Play("Walk");
            }

            Move(x, y);
        }

        void Move(float x, float y)
        {
            direc = new Vector2(x, y);

            newPos = (Vector2)transform.position + direc;

            transform.position = Vector2.MoveTowards(transform.position, newPos, Time.deltaTime * moveSpeed);

            if (transform.position.y < minY)
            {
                pos = new Vector2(transform.position.x, minY);
                transform.position = pos;
            }

            if (transform.position.y > maxY)
            {
                pos = new Vector2(transform.position.x, maxY);
                transform.position = pos;
            }

            float yRange = Mathf.Abs(maxY - minY);

            float onePerc = yRange / 100;

            float currentY = transform.position.y - minY;

            float percValue = currentY / onePerc;

            float scaleRange = Mathf.Abs(maxScale - minScale);

            float scaOnePerc = scaleRange / 100;

            float newScaleValue = maxScale - (scaOnePerc * percValue);

            Vector3 newScale = transform.localScale;
            newScale.x = newScaleValue;
            newScale.y = newScaleValue;
            if (x > 0)
            {
                theRenderer.flipX = true;
            }
            else if (x < 0)
            {
                theRenderer.flipX = false;
            }

            transform.localScale = newScale;
        }
    }
}