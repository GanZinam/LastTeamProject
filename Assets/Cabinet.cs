﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    GameObject intoObj;
    [SerializeField]
    GameObject foundObj;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
            {
                // 찾기
                foundObj.SetActive(true);
            }
            else if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
            {
                // 들어가기
                intoObj.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foundObj.SetActive(false);
            intoObj.SetActive(false);
        }
    }
}
