using UnityEngine;
using System.Collections;


namespace LudumDare37
{

    public class AsteroidCreator : MonoBehaviour
    {
        public GameObject[] asteroidPrefabs;
        public GameObject[] asteroidSpawn;  //An array of spawn points bullets can spawn from.
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
            print("Created");
            bool successful = false;

            while (!successful)
            {
                i = Random.Range(0, asteroidSpawn.Length);
                randomAsteroid = Mathf.RoundToInt(Random.Range(-0.49f, 2.49f));

                if (!asteroidSpawn[i].GetComponent<PlayerInside>().inside)
                {
                    Quaternion newRot = Quaternion.Euler(0, 0, Random.Range(asteroidSpawn[i].transform.rotation.eulerAngles.z - 45, asteroidSpawn[i].transform.rotation.eulerAngles.z + 45));
                    Instantiate(asteroidPrefabs[randomAsteroid], asteroidSpawn[i].transform.position, newRot);
                    successful = true;
                }
            }

            createTime = Random.Range(0.75f, 1.75f);
            Invoke("Create", createTime);
        }
    }
}