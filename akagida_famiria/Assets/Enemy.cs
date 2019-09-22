using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameManagement gm;
    public float maxHP = 100f;
    private float enemyHP;

    //public GameObject[] Playerbullet;
    public GameObject Enemybullet;

    public GameObject spawner;

    private Player player;


    IEnumerator Start()
    {
        InitEnemy();
        yield return new WaitForSeconds(1.00f);
        while (true)
        {
            
            GameObject obj = Instantiate(Enemybullet, transform.localPosition, transform.localRotation);
            obj.transform.SetParent(spawner.transform, false);
            // 1.00秒待つ
            yield return new WaitForSeconds(1.00f);
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

        enemyHP = maxHP;
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

            gm.ChangeEnemyBar(enemyHP / maxHP);
            //当たった玉を消す
            Destroy(c.gameObject);
        }



    }
}
