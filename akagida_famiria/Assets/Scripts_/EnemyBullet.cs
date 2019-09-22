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



    private Vector3 verocityDirection;

    public Vector2 direction = new Vector2(0.5f, 0.5f);

    void Start()
    {
        angle = getAngles() + defAngle;
        var direction = GetDirection(angle);
        verocityDirection = direction * speed;
        var bulletAngles = transform.localEulerAngles;
        bulletAngles.z = angle - 90;
        transform.localEulerAngles = bulletAngles;

        Destroy(gameObject, 3);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        //変更
        //rb.velocity = transform.up.normalized * speed;
        transform.localPosition += verocityDirection;

        if (this.transform.localPosition.y <= -600)
        {
            Destroy(this.gameObject);
        }
    }

    public static float angles = 0f;
    public static float defAngle = 0f;


    private float getAngles()
    {
        if (angles == 135f)
        {
            angles = 45f;
        }
        else if (angles == 90f)
        {
            angles = 135f;
        }
        else
        {
            angles = 90f;
        }
        return angles;
    }

    private float angle;

    public Vector3 GetDirection(float angle)
    {
        return new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0);
    }


}
