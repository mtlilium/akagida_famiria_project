using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wairo : MonoBehaviour
{
    private Vector3 spawnPointLeft = new Vector3(-640, 150,0);
    private Vector3 spawnPointRight = new Vector3(640, 150,0);
    public GameObject wairoSprite;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnWairo", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnWairo()
    {
        int rnd = Random.Range(0, 10);
        if (rnd <= 4)
        {
            this.transform.localPosition = spawnPointLeft;
            this.transform.rotation = Quaternion.Euler(0, 0, -70);
        }
        else
        {
            this.transform.localPosition = spawnPointRight;
            this.transform.rotation = Quaternion.Euler(0, 0, 70);
        }
        GameObject obj = Instantiate(wairoSprite, this.transform.position, transform.rotation);
        obj.transform.SetParent(this.transform, false);

        Invoke("SpawnWairo", 5);
    }
}
