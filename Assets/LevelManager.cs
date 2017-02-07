﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GM
{
    public class LevelManager : MonoBehaviour
    {
        //public GameObject loadingCanvas;
        public static int myLevel;

        [SerializeField]
        GameObject introCanvas;
        [SerializeField]
        GameObject loadingObj;

        void Start()
        {
            DontDestroyOnLoad(this);

            if (myLevel.Equals(0))
            {
                introCanvas.SetActive(true);
            }
        }

        public IEnumerator loading(bool isClear)
        {
            loadingObj.SetActive(true);

            yield return new WaitForSeconds(1);
            if (isClear)
            {
                myLevel++;
            }
            else
            {

            }

            SceneManager.LoadScene("Game");
            yield return new WaitForSeconds(4);
        }
    }
}