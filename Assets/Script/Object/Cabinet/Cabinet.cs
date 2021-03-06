﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    GameObject intoObj;
    [SerializeField]
    GameObject foundObj;
    [SerializeField]
    GameObject murderObj;

    public Vector2 PolicePos_M;
    [SerializeField]
    CabinetMurder myMurder;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SMng.CabinetIn = true;

            if (SMng.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
            {
                // 찾기
                foundObj.SetActive(true);

            }
            else if (SMng.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
            {
                // 들어가기
                intoObj.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Police"))
        {
            if (SMng.HideWide.Equals(0))
            {
                murderObj.SetActive(true);
                myMurder.tempTargetPolice = other.gameObject;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SMng.CabinetIn = false;
            foundObj.SetActive(false);
            intoObj.SetActive(false);
        }
        if (other.gameObject.CompareTag("Police"))
        {
            murderObj.SetActive(false);
            myMurder.tempTargetPolice = null;
        }
    }

    void CabinetIn()
    {
        if (SMng.Hide)
        {
            SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0f);
        }
        else
        {
            SMng.Instance.Hero.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }

    void Cabinetbool()
    {
        transform.GetComponent<Animator>().SetBool("Cabinet", false);
        SMng.interection = false;
    }

    void _CabinetMurder()
    {
        if (myMurder != null)
        {
            myMurder.SendMessage("BeCaught");       // 경찰에게 붙잡혔다는 메세지를 보내줌
        }
    }
    void CabinetMurderFini()
    {
        GameObject Child = transform.Find("MurderIcon(Knife)").gameObject;
        Child.SetActive(false);
        transform.GetComponent<Animator>().SetBool("CabinetOpen", false);
    }
}
