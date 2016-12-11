using UnityEngine;
using System.Collections;

namespace LudumDare37
{

    public class CreateBarrels : MonoBehaviour
    {

        public GameObject[] barrelPrefab;
        public Transform barrelSpawn;

        // Use this for initialization
        void Start()
        {
            InstantiateBarrel();
        }

        void InstantiateBarrel()
        {
            Instantiate(barrelPrefab[Mathf.RoundToInt(Random.Range(-0.49f, 1.49f))], barrelSpawn.position, barrelSpawn.rotation);
            Invoke("InstantiateBarrel", 3.0f);
        }
    }
}
