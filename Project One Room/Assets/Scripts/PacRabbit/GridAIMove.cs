using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LudumDare37
{
    public class GridAIMove : GridMoveRestrict
    {
        // Private Variables
        private bool lastTopCollision = false;
        private bool lastBottomCollision = false;
        private bool lastLeftCollision = false;
        private bool lastRightCollision = false;

        new void FixedUpdate()
        {
            if (PacRabbitController.instance.GetPlaying())
            {
                if (HasReachedCell())
                {
                    if (lastTopCollision != topTrigger.isColliding ||
                    lastBottomCollision != bottomTrigger.isColliding ||
                    lastLeftCollision != leftTrigger.isColliding ||
                    lastRightCollision != rightTrigger.isColliding)
                    {
                        TryMove();
                    }

                    lastTopCollision = topTrigger.isColliding;
                    lastBottomCollision = bottomTrigger.isColliding;
                    lastLeftCollision = leftTrigger.isColliding;
                    lastRightCollision = rightTrigger.isColliding;
                }
                base.FixedUpdate();
            }
        }

        new public void ResetThis()
        {
            base.ResetThis();

            lastTopCollision = false;
            lastBottomCollision = false;
            lastLeftCollision = false;
            lastRightCollision = false;
        }

        public void TryMove()
        {
            List<string> options = new List<string>();

            if (!topTrigger.isColliding)
            {
                options.Add("Up");
            }

            if (!bottomTrigger.isColliding)
            {
                options.Add("Down");
            }

            if (!leftTrigger.isColliding)
            {
                options.Add("Left");
            }

            if (!rightTrigger.isColliding)
            {
                options.Add("Right");
            }

            if (options.Count == 0)
            {
                SetDirection(-direction);
                return;
            }
            else
            {
                Vector2 newDirec = new Vector2();

                if (options.Count > 1)
                {
                    if (direction == Vector2.down &&
                        options.Contains("Up"))
                    {
                        options.Remove("Up");
                    }
                    if (direction == Vector2.up &&
                        options.Contains("Down"))
                    {
                        options.Remove("Down");
                    }
                    if (direction == Vector2.right &&
                        options.Contains("Left"))
                    {
                        options.Remove("Left");
                    }
                    if (direction == Vector2.left &&
                        options.Contains("Right"))
                    {
                        options.Remove("Right");
                    }
                }
                int rnd = Random.Range(0, options.Count);

                string moveChoice = options[rnd];

                switch (moveChoice)
                {
                    case "Up": // UP
                        newDirec = Vector2.up;
                        break;
                    case "Down": // DOWN
                        newDirec = Vector2.down;
                        break;
                    case "Left": // LEFT
                        newDirec = Vector2.left;
                        break;
                    case "Right": // RIGHT
                        newDirec = Vector2.right;
                        break;
                }
                SetDirection(newDirec);
            }
        }
    }
}