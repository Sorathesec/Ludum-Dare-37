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
        float i = 0;
        int randomAsteroid;
        Quaternion randomRotation;
        Vector2 randomPosition;

        void Start()
        {
            Create();
        }
        // Update is called once per frame
        void Create()
        {
            i = Random.Range(0.0f, 2.0f);
            if (i < 1)
            {
                print("1 selected");
                randomPosition = new Vector2(Random.Range(-12f, 0f), 8.0f);
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(190f, 260f));
            }
            else if (i < 2 )
            {
                print("2 selected");
                randomPosition = new Vector2(Random.Range(0f, 12f), 8.0f);
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(120f, 190f));
            }
            else if (i < 3)
            {
                randomPosition = new Vector2(Random.Range(14.0f, 28.0f), 6.8f);
                randomRotation = Quaternion.Euler(0f, 0f, Random.Range(180f, 270f));
            }
            randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));
            Instantiate(asteroidPrefabs[randomAsteroid], randomPosition, randomRotation);

            createTime = Random.Range(3.0f, 5.0f);
            Invoke("Create", createTime);
        }

        void Update()
        {

        }
    }
}
