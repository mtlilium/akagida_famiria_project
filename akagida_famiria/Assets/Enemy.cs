using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    
    //public GameObject[] Playerbullet;
    public GameObject Enemybullet;

    public GameObject spawner;


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
        this.transform.localPosition = new Vector2(0, 200);
    }

}
