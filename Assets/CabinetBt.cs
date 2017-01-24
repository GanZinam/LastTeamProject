﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetBt : MonoBehaviour
{
    [SerializeField]
    GameObject intoObj;
    [SerializeField]
    GameObject foundObj;
    [SerializeField]
    GameObject foundItemPopup;

    void Start()
    {

    }

    void Update()
    {
        // 문들어가는거 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("GoCabinet"))
                {
                    if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_HAND))
                    {
                        // 찾기
                        foundItemPopup.SetActive(true);
                        SMng.Instance.Direction = 3;
                    }
                    else if (SMng.Instance.Hero_weapon.Equals(WEAPON.WEAPON_GUN))
                    {
                        // 들어가기
                        if (!SMng.Instance.Hide)
                        {
                            SMng.Instance.Hide = true;
                            SMng.Instance.Direction = 3;
                            SMng.Instance.HideWide = 0;
                        }
                        else
                        {
                            SMng.Instance.Hide = false;
                            SMng.Instance.Direction = 0;
                            SMng.Instance.HideWide = 1;
                        }
                    }
                }
            }
        }
    }

    public void ExitBt()
    {
        SMng.Instance.Direction = 0;
    }

}
