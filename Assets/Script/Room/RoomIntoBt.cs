﻿using UnityEngine;
using System.Collections;

public class RoomIntoBt : MonoBehaviour {

    public GameObject Room;

	// Use this for initialization
	void Start () {
	
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
                if (hit.transform.CompareTag("GoDoor"))
                {
                    if (Room.active.Equals(false))
                    {
                        Room.SetActive(true);
                    }
                    else
                    {
                        Room.SetActive(false);
                    }
                }
            }
        }
    }
}