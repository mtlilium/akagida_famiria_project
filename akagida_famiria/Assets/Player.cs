﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 300.0f;
    float xLimit = 800.0f;

    // PlayerBulletプレハブ
    public GameObject[] Playerbullet;
    public GameObject spawner;

    IEnumerator Start()
    {
        InitPlayer();
        yield return new WaitForSeconds(1.00f);
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            int rnd = Random.Range(0, 3);
            GameObject obj = Instantiate(Playerbullet[rnd], transform.position, transform.rotation);
            obj.transform.SetParent(this.transform.transform,false);
            // 1.00秒待つ
            yield return new WaitForSeconds(1.00f);
        }
    }

    // Start is called before the first frame update
    
    
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
            this.transform.localPosition = new Vector2(Mathf.Max(-1*xLimit,this.transform.localPosition.x - Time.deltaTime * moveSpeed), this.transform.localPosition.y);
        }
        else
        {
            this.transform.localPosition = new Vector2(Mathf.Min(xLimit, this.transform.localPosition.x + Time.deltaTime * moveSpeed), this.transform.localPosition.y);
        }
    }

    void InitPlayer()
    {
        this.transform.localPosition = new Vector2(0, -350);
    }
}
