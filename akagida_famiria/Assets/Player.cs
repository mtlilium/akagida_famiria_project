﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        InitPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move("LEFT");
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move("RIGHT");
        }
    }
    // 機体の移動
    void Move(string v)
    {
        if (v == "LEFT")
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x - Time.deltaTime * moveSpeed, this.transform.localPosition.y);
        }
        else
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x + Time.deltaTime * moveSpeed, this.transform.localPosition.y);
        }
    }

    void InitPlayer()
    {
        this.transform.localPosition = new Vector2(0, -350);
    }
}
