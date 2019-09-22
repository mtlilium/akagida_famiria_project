using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20;
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
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("MIKAMI!!!!");
    }
}

