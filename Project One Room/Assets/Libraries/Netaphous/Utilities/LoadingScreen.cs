using UnityEngine;
using System.Collections;

namespace Netaphous.Utilities
{
    public class LoadingScreen : MonoBehaviour
    {
        public static string levelName;

        // Use this for initialization
        void Start()
        {
            LoadScene.LoadLevel(levelName);
        }
    }
}
