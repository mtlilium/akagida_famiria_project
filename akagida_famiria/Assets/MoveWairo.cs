using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWairo : MonoBehaviour
{
    private float wairoSpeed = 8;
    // Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        MoveMoney();
        if (Mathf.Abs(this.transform.localPosition.y) >= 1000)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveMoney()
    {
        rb.velocity = transform.up.normalized * wairoSpeed;
    }

}
