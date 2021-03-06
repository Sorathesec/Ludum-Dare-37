﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Netaphous.Utilities
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField]
        private string loadingSceneName = "";
        static public LoadScene instance;

        void OnEnable()
        {
            instance = this;
        }

        public static void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

        public static void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void LoadLevelWithLoading(string name)
        {
            LoadingScreen.levelName = name;
            LoadLevel(loadingSceneName);
        }
    }
}