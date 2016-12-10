using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Netaphous.Utilities
{
    public class PoolManager : MonoBehaviour
    {
        // Public vairbales
        // To be accessed elsewhere
        public static PoolManager current = null;

        // To be set in the editor
        public string[] names;
        public GameObject[] pooledObjects;
        public int[] poolAmounts;

        // Private varaibles
        // Logic variables
        private Hashtable mainPool = new Hashtable();

        // Code optimisation
        private List<GameObject> tempList;
        private List<GameObject> objList;
        private GameObject obj;
        private int i;

        void Awake()
        {
            if (current == null)
            {
                current = this;
            }
            else
            {
                Destroy(this);
            }

            DontDestroyOnLoad(this);
        }

        void Start()
        {
            tempList = new List<GameObject>();

            for (int i = 0; i < names.Length; i++)
            {
                objList = new List<GameObject>();

                for (int j = 0; j < poolAmounts[i]; j++)
                {
                    obj = (GameObject)Instantiate(pooledObjects[i]);
                    obj.SetActive(false);
                    obj.transform.parent = transform;
                    objList.Add(obj);
                }

                mainPool.Add(names[i], objList);
            }

            ResetPool();
        }

        public GameObject GetPooledObject(string name)
        {
            if (mainPool.ContainsKey(name))
            {
                tempList = mainPool[name] as List<GameObject>;

                for (i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i] != null &&
                        !tempList[i].activeInHierarchy)
                    {
                        return tempList[i];
                    }
                }
            }
            print("No " + name + " left!");
            return null;
        }

        public void ResetPool()
        {
            for (i = 0; i < tempList.Count; i++)
            {
                if (tempList[i] != null &&
                    tempList[i].activeInHierarchy)
                {
                    tempList[i].SetActive(false);
                }
            }
        }
    }
}