﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SComputerMini : MonoBehaviour
{
    public GameObject[] WallGame = new GameObject[6];
    [HideInInspector]
    public BoxCollider2D[] BoxCollider = new BoxCollider2D[6];

    public SScroll[] ScrollScrp = null;

    public int nCount;          // 알파벳 카운트?
    public bool bCheck;

    // timer
    public float fTimer;        // 타이머 시간
    int nTime;
    int nMinutes;
    int nSeconds;
    float fMillisecond;
    //public Text TimerText = null;

    void Start()
    {
        nCount = 0;
        fTimer = 180f;
    }

    void Update()
    {
        //Timer();
    }

    //void Timer()
    //{
    //    if (fTimer > 0)
    //    {
    //        fTimer -= Time.deltaTime;
    //        nTime = (int)fTimer;
    //        nMinutes = nTime / 60;
    //        nSeconds = nTime % 60;
    //        fMillisecond = fTimer * 1000;
    //        fMillisecond = (fMillisecond % 1000);
    //        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", nMinutes, nSeconds, fMillisecond);
    //    }
    //    if (fTimer <= 0)
    //    {
    //        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", 0, 0, 0);
    //        Time.timeScale = 0;
    //    }
    //}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bar"))
        {
            bCheck = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetMouseButtonDown(0) /*|| Input.GetKeyDown(KeyCode.Space) */&& bCheck)
        {
            Debug.Log("asdfasdfasdfasdfasdf");
            switch (nCount)
            {
                case 0:
                    ScrollScrp[0].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
                case 1:
                    ScrollScrp[1].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
                case 2:
                    ScrollScrp[2].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
                case 3:
                    ScrollScrp[3].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
                case 4:
                    ScrollScrp[4].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
                case 5:
                    ScrollScrp[5].scrollSpeed = 0f;
                    bCheck = false;
                    nCount++;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Bar"))
        {
            bCheck = false;
        }
    }
}