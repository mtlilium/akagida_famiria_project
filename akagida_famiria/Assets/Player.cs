using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed;
    float xLimit = 640.0f;

    private float attackPoint = 5.0f;

    // PlayerBulletプレハブ
    public GameObject[] Playerbullet;
    //スポナー
    public GameObject spawner;

    private GameManagement gm;

    public GameObject yuri;

    IEnumerator Start()
    {
        InitPlayer();
        yield return new WaitForSeconds(1.00f);
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            int rnd = Random.Range(0, 999999999)%20;
            GameObject obj = Instantiate(Playerbullet[rnd], transform.localPosition, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
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
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move("RIGHT");
        }

        if(moveSpeed <= 100)
        {
            Invoke("HelpYuri", 2);
        }
    }


    // 機体の移動
    void Move(string v)
    {
        if (v == "LEFT")
        {
            this.transform.localPosition = new Vector2(Mathf.Max(-1 * xLimit, this.transform.localPosition.x - Time.deltaTime * moveSpeed), this.transform.localPosition.y);
        }
        else
        {
            this.transform.localPosition = new Vector2(Mathf.Min(xLimit, this.transform.localPosition.x + Time.deltaTime * moveSpeed), this.transform.localPosition.y);
        }
    }

    //衝突時のロジック
    void OnTriggerEnter2D(Collider2D c)
    {

        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "EnemyBullet")
        {

            //PlayerがBulletに当たった時のロジック
            gm.CalScore(2f);
            //当たった玉を消す
            Destroy(c.gameObject);
        }

        if(c.tag == "Wairo")
        {
            moveSpeed -= 50;
            if(moveSpeed <= 50)
            {
                moveSpeed = 50;
            }
            Destroy(c.gameObject);
        }


    }

    public float GetAttackPoint()
    {
        return attackPoint;
    }


    void InitPlayer()
    {
        moveSpeed = 300.0f;
        gm = GameObject.Find("GameManager").GetComponent<GameManagement>();
        this.transform.localPosition = new Vector2(0, -380);
    }

}
