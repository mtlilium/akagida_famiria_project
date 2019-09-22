using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYuri : MonoBehaviour
{
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
        if (Mathf.Abs(this.transform.localPosition.y) >= 1500)
        {
            Destroy(this.gameObject);
        }
    }

}
