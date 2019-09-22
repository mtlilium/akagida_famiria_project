using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManagement gm;
    public float maxHP;
    private float enemyHP;

    //public GameObject[] Playerbullet;
    public GameObject Enemybullet;

    public GameObject spawner;

    private Player player;

    private bool isDead;

    IEnumerator Start()
    {
        InitEnemy();
        yield return new WaitForSeconds(1.00f);
        while (true)
        {

            //yield return new WaitForSeconds(1.00f);
            while (true)
            {
                EnemyBullet.defAngle = GetRad();
                int rnd = Random.Range(0, 5);

                rnd = 3;

                if (rnd == 0)
                {
                    yukariShot();
                }
                else if (rnd == 1)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        kokkaiShot(i);
                        yield return new WaitForSeconds(0.30f);
                    }

                }
                else
                {
                    defaultShot();
                }

                // 1.00秒待つ
                yield return new WaitForSeconds(1.00f);
            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void InitEnemy()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagement>();
        player = GameObject.Find("Player").GetComponent<Player>();
        this.transform.localPosition = new Vector2(0, 200);

        maxHP = GameManagement.stage * 30 + (int)(GameManagement.stage / 3) * 9; //30,60,99
        enemyHP = maxHP;
        Debug.Log("ENEMY HP:" + maxHP);
        isDead = false;
    }

    public bool Defeat()
    {
        return isDead;
    }
    public int GetMaxHP()
    {
        return (int)maxHP;
    }
    //衝突時のロジック
    void OnTriggerEnter2D(Collider2D c)
    {

        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "PlayerBullet")
        {

            //PlayerがBulletに当たった時のロジック
            gm.CalScore(-0.2f);
            enemyHP -= player.GetAttackPoint();
            if(enemyHP <= 0.0f)
            {
                enemyHP = 0.0f;
                isDead = true;
            }
            gm.ChangeEnemyBar(enemyHP / maxHP);
            //当たった玉を消す
            Destroy(c.gameObject);
        }

    }


        //弾幕関数群
        //後Start内も少し変更している


    public GameObject Yukari;
    public GameObject Kokkai;

    //public GameObject Player;

    //public GameObject[] Playerbullet;
    //ここに弾幕として扱いたいプレハブを設定する
    //弾幕のプレハブ + どのように発射するのかを記述したスクリプト




    void defaultShot()
    {

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(Enemybullet, transform.localPosition, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
        }
    }

    void kokkaiShot(int i)
    {
        if (i <= 2)
        {
            Vector3 vector = new Vector3(200 * (i - 1) * 2.5f, 480f, 0f);
            vector += transform.localPosition;
            vector.y -= transform.localPosition.y;
            GameObject obj = Instantiate(Kokkai, transform.localPosition + vector, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
        }
        else if (i <= 5)
        {
            i -= 3;
            Vector3 vector = new Vector3(200 * (i - 1) * 2.0f, 480f, 0f);
            vector += transform.localPosition;
            vector.y -= transform.localPosition.y;
            GameObject obj = Instantiate(Kokkai, transform.localPosition + vector, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
        }
        else
        {
            i -= 6;
            Vector3 vector = new Vector3(200 * (i - 1) * 1.3f, 480f, 0f);
            vector += transform.localPosition;
            vector.y -= transform.localPosition.y;
            GameObject obj = Instantiate(Kokkai, transform.localPosition + vector, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
        }

    }

    void yukariShot()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(Yukari, transform.localPosition, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
        }
    }



    float GetRad()
    {
        float rad = Mathf.Atan2(this.transform.localPosition.x - player.transform.localPosition.x, transform.localPosition.y - player.transform.localPosition.y);
        return -rad * Mathf.Rad2Deg;
    }








}
