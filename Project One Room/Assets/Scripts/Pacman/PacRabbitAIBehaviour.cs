using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class PacRabbitAIBehaviour : MonoBehaviour, Killable
    {
        [SerializeField]
        private float moveSpeed = 0.5f;
        Vector3 startPos;

        Transform[] children;

        private bool isDead = false;

        // Use this for initialization
        void Awake()
        {
            startPos = transform.position;

            children = GetComponentsInChildren<Transform>();
        }

        void Update()
        {
            if(PacRabbitController.instance.GetPlaying() && isDead)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * moveSpeed);    // Move there
                if(transform.position == startPos)
                {
                    Revive();
                }
            }
        }

        public void Kill()
        {
            for(int i = 0; i < children.Length; i++)
            {
                if (children[i] != transform)
                {
                    children[i].gameObject.SetActive(false);
                }
            }

            GetComponent<Collider2D>().enabled = false;
            GetComponent<GridAIMove>().enabled = false;

            isDead = true;
        }

        public void Revive()
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<GridAIMove>().enabled = true;
            for (int i = 0; i < children.Length; i++)
            {
                children[i].gameObject.SetActive(true);
            }
            
            isDead = false;
        }

        public GameObject ReturnGameobject()
        {
            return gameObject;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            print(other.gameObject.tag);
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PacRabbitPlayerBehavour>().Kill();
            }
        }

        public void Reset()
        {
            transform.position = startPos;
            isDead = false;
            GetComponent<GridAIMove>().ResetThis();
        }
    }
}