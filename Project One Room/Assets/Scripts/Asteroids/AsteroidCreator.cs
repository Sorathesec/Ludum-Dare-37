using UnityEngine;
using System.Collections;


namespace LudumDare37
{

    public class AsteroidCreator : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs;
        public Transform[] asteroidSpawn;  //An array of spawn points bullets can spawn from.
        public float createTime = 4.0f;
        AudioSource gunAudio;
        public AudioClip shootClip;
        int i = 0;
        int randomAsteroid;
        Quaternion randomRotation;

        void Start()
        {
            Reset();
        }

        void Reset()
        {
            Invoke("Create", createTime * 3);
        }

        void Create()
        {
            i = Mathf.RoundToInt(Random.Range(0.51f, 4.49f));
            if (i <= 1)
            {
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, -120f));
            }
            else if (i <= 2 )
            {
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(120f, 220f));
            }
            else if (i <= 3)
            {
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(-300f, -250f));
            }
            else if (i <= 4)
            {
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(40f, -40f));
            }
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], asteroidSpawn[i-1].position, randomRotation);

            createTime = Random.Range(0.75f, 1.75f);
            Invoke("Create", createTime);
        }
    }
}
