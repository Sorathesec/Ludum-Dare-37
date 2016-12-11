using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class CreateBarrels : MonoBehaviour
    {

        public GameObject[] barrelPrefab;
        public Transform barrelSpawn;

        [SerializeField]
        private float minSpawnTime = 3.0f;
        [SerializeField]
        private float maxSpawnTime = 8.0f;

        // Use this for initialization
        void Start()
        {
            InstantiateBarrel();
        }

        void InstantiateBarrel()
        {
            Instantiate(barrelPrefab[Mathf.RoundToInt(Random.Range(-0.49f, 1.49f))], barrelSpawn.position, barrelSpawn.rotation);
            float randomTimer = Random.Range(minSpawnTime, maxSpawnTime);
            Invoke("InstantiateBarrel", randomTimer);
        }
    }
}
