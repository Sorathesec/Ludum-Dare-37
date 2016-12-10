using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class CreateBarrels : MonoBehaviour
    {

        public GameObject barrelPrefab;
        public Transform barrelSpawn;
        float randomNumber;

        // Use this for initialization
        void Start()
        {
            InstantiateBarrel();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InstantiateBarrel()
        {
            Instantiate(barrelPrefab, barrelSpawn.position, barrelSpawn.rotation);
            randomNumber = Random.Range(2.0f, 4.0f);
            Invoke("InstantiateBarrel", 3.0f);
        }
    }
}
