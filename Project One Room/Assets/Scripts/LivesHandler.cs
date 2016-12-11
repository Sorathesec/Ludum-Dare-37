using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LudumDare37
{
    public class LivesHandler : MonoBehaviour
    {
        [HideInInspector]
        public int lives = 3;

        [SerializeField]
        private int maxLives = 3;
        [SerializeField]
        private GameObject lifeDisplayPrefab;
        [SerializeField]
        private float lifeDisplacement = 1.0f;

        private List<GameObject> lifeObjects;

        // Use this for initialization
        void Awake()
        {
            lives = maxLives;

            lifeObjects = new List<GameObject>();
            for (int i = 0; i < maxLives; i++)
            {
                Vector3 spawnPos = transform.position;
                spawnPos.x += lifeDisplacement * i;
                lifeObjects.Add(Instantiate(lifeDisplayPrefab, spawnPos, transform.rotation, transform) as GameObject);
            }
        }

        public bool RemoveLife()
        {
            lives--;

            GameObject life = lifeObjects[lifeObjects.Count - 1];

            lifeObjects.Remove(life);

            Destroy(life);

            if (lives <= 0)
            {
                return true;
            }
            return false;
        }
    }
}