using UnityEngine;
using System.Collections;

namespace Netaphous.Destructor
{
    public abstract class BasicPoolManager : MonoBehaviour
    {
        // Public variables
        // To be set in the editor
        public GameObject objectPrefab;

        // Private variables
        // Can be accessed in the editor
        [SerializeField]
        protected int pooledAmount = 50;

        // Script logic
        private GameObject[] objectPool;

        protected void CreatePool()
        {
            objectPool = new GameObject[pooledAmount];

            for (int i = 0; i < pooledAmount; i++)
            {
                objectPool[i] = Instantiate(objectPrefab) as GameObject;
                objectPool[i].SetActive(false);
            }
        }

        protected GameObject GetPooledItem()
        {
            for (int i = 0; i < pooledAmount; i++)
            {
                if (objectPool[i] != null &&
                    !objectPool[i].activeInHierarchy)
                {
                    return objectPool[i];
                }
            }
            return null;
        }
        
        protected void ResetPool()
        {
            for (int i = 0; i < objectPool.Length; i++)
            {
                if (objectPool[i] != null &&
                    objectPool[i].activeInHierarchy)
                {
                    objectPool[i].SetActive(false);
                }
            }
        }
    }
}