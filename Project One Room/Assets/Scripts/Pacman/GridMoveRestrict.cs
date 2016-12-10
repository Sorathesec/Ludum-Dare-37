using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public abstract class GridMoveRestrict : MonoBehaviour
    {
        // Private variables
        // Accessible in the editor
        [SerializeField]
        private float moveSpeed = 1.0f;
        [SerializeField]
        protected float gridSize = 0.5f;
        [SerializeField]
        protected GridMoveTrigger topTrigger;
        [SerializeField]
        protected GridMoveTrigger bottomTrigger;
        [SerializeField]
        protected GridMoveTrigger leftTrigger;
        [SerializeField]
        protected GridMoveTrigger rightTrigger;

        // Script logic
        protected Vector2 direction;
        private Vector2 newDirection;
        protected Vector2 nextPos;

        // Code optimisation
        protected Transform theTransform;

        // Use this for initialization
        protected void Awake()
        {
            theTransform = transform;

            ResetThis();
        }

        public void ResetThis()
        {
            nextPos = transform.position;
            direction = new Vector2();
            newDirection = new Vector2();
        }

        protected void SetDirection(Vector2 direction)
        {
            newDirection = direction;
            Invoke("ResetNewDirection", 0.5f);
        }

        private void ResetNewDirection()
        {
            newDirection = direction;
        }

        protected void ForceDirection(Vector2 direction)
        {
            this.direction = direction;

            CalculateNextPos();
        }

        protected void FixedUpdate()
        {
            if (PacRabbitController.instance.GetPlaying())
            {
                if (HasReachedCell())
                {
                    TryChangeDirection();

                    CalculateNextPos();
                }

                Move();
            }
        }
        protected bool HasReachedCell()
        {
            return transform.position == (Vector3)nextPos;
        }

        private void TryChangeDirection()
        {
            if (direction != newDirection)
            {
                if (newDirection == Vector2.left &&
                    !leftTrigger.isColliding)
                {        // Left
                    direction = newDirection;
                }

                if (newDirection == Vector2.right &&
                    !rightTrigger.isColliding)
                {        // Right
                    direction = newDirection;
                }

                if (newDirection == Vector2.up &&
                    !topTrigger.isColliding)
                {        // Up
                    direction = newDirection;
                }

                if (newDirection == Vector2.down &&
                    !bottomTrigger.isColliding)
                {        // Down
                    direction = newDirection;
                }
            }
        }

        private void CalculateNextPos()
        {
            if (direction == Vector2.left &&
                !leftTrigger.isColliding)
            {        // Left
                nextPos += Vector2.left * gridSize;
            }

            if (direction == Vector2.right &&
                !rightTrigger.isColliding)
            {        // Right
                nextPos += Vector2.right * gridSize;
            }

            if (direction == Vector2.up &&
                !topTrigger.isColliding)
            {        // Up
                nextPos += Vector2.up * gridSize;
            }

            if (direction == Vector2.down &&
                !bottomTrigger.isColliding)
            {        // Down
                nextPos += Vector2.down * gridSize;
            }
            newDirection = direction;
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * moveSpeed);    // Move there
        }
    }
}