using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = -10;

    // Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D rb;

    // ゲーム起動時の処理
    void Awake()
    {
        // Rigidbody2D コンポーネントを取得して変数 rb に格納
        rb = GetComponent<Rigidbody2D>();
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

        if (this.transform.localPosition.y <= -1200)
        {
            Destroy(this.gameObject);
        }
    }

}
