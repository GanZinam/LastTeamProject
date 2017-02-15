﻿using UnityEngine;
using System.Collections;

public enum WEAPON { WEAPON_GUN, WEAPON_HAND }

public class SMng : MonoBehaviour
{
    private static SMng _Instance = null;

    public static SMng Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(SMng)) as SMng;
                if (!_Instance)
                    Debug.LogError("GM instance Error");
            }
            return _Instance;
        }
    }

    public GameObject hideWeapon;

    public GameObject Hero = null;          // Hero GameObject
    public GameObject DoorBt = null;        // DoorBt GameObject

    public static WEAPON Hero_weapon;              // 0.상호작용 1. 전투

    public static bool Middle_touch;               // 중앙 터치 유무

    //@ 0 = 아무대도아닌상태 1= 오른쪽 2 = 왼쪽 3 = 상호작용했을때
    public static int Direction = 0;

    public static bool interection;                // true  = 상호작용 중 false = 상호작용 ㄴ

    //@ 주인공이 앉아있는지 아닌지 true = 앉아있는것 false = 서있는것
    public static bool sit = false;
    public static bool RoomInit;                   // 방안에 들어갔나 나왔나
    public static bool Hide = false;               // 숨어있는지 아닌지

    //@ 숨어있는 상자 방향
    public static bool Hide_right = false;
    public static bool Hide_left = false;

    //@ 주인공 애니메이션
    public Animator HeroAnimator;

    //@ 미니게임
    public static bool bDownCheck;
    public bool[] MGComplite = new bool[3];

    public static int HideWide = 1;          //케비넷 으로 들어가면 0


    Vector2 recentHighPos = new Vector2(300, 150);

    [HideInInspector]
    public bool[] isStating = new bool[7];

    [SerializeField]
    GameObject statePrefab;
    [SerializeField]
    GameObject state;

    public bool CabinetIn;          // 히어로가 캐비넷에 들어가있는지
    public bool CabinetChangeUI;    // 히어로가 캐비넷에 들어가잇을때 바꾸면 아이콘 바뀌는거


    public Inventory _inventory;
    public GM.LevelManager _level;

    public bool LevelMng_PoliceDie = false;


    public void createState(int itemCode)
    {
        GameObject obj = Instantiate(statePrefab, state.transform) as GameObject;
        obj.transform.localPosition = recentHighPos;
        for (int i = 0; i < 7; i++)
        {
            obj.transform.localPosition -= new Vector3(0, 50);

            if (!isStating[i])
            {
                isStating[i] = true;
                obj.GetComponent<StatePopup>().idx = i;
                if (itemCode.Equals(100))
                    obj.GetComponent<StatePopup>().text.text = "EMPTY";
                else
                    obj.GetComponent<StatePopup>().text.text = itemCode + "";
                break;
            }
        }
    }

    public void changeWeapon()
    {
        Hero_weapon = Hero_weapon.Equals(WEAPON.WEAPON_HAND) ? WEAPON.WEAPON_GUN : WEAPON.WEAPON_HAND;

        if (CabinetIn)
        {
            CabinetChangeUI = true;
        }
    }
}