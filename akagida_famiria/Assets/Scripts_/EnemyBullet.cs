using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed;

    // Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D rb;

    private GameManagement gm;

    // ゲーム起動時の処理
    void Awake()
    {
        // Rigidbody2D コンポーネントを取得して変数 rb に格納
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagement>();
        speed = GameManagement.enemyBulletSpeed;
    }

    void Start()
    {

    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        rb.velocity = transform.up.normalized * speed;

        if (this.transform.localPosition.y <= -600)
        {
            Destroy(this.gameObject);
        }
    }

}
