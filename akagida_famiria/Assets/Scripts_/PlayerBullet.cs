using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed = 10;
    private GameManagement gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagement>();
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
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        if(this.transform.localPosition.y >= 1200)
        {
            Destroy(this.gameObject); //PlayerBullet
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("MIKAMI!!!!");
    }
}

