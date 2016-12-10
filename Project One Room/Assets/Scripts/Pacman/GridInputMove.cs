using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public class GridInputMove : GridMoveRestrict
    {

        
        new void FixedUpdate()
        {
            if (PacRabbitController.instance.GetPlaying())
            {
                TestDirection();

                base.FixedUpdate();
            }
        }

        private void TestDirection()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector2 newDir = direction;

            if (x > 0)
            {
                newDir = Vector2.right;
            }

            if (x < 0)
            {
                newDir = Vector2.left;
            }

            if (y > 0)
            {
                newDir = Vector2.up;
            }

            if (y < 0)
            {
                newDir = Vector2.down;
            }

            if (newDir != direction)
            {
                if (newDir == -direction)
                {
                    ForceDirection(newDir);
                }
                SetDirection(newDir);
            }
        }
    }
}