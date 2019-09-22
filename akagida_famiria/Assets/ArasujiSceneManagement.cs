using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArasujiSceneManagement : MonoBehaviour
{
    public Sprite[] arasuji;
    private Image arasujiGamen;
    private int cnt;
    // Start is called before the first frame update
    void Start()
    {
        arasujiGamen = GameObject.Find("ArasujiGamen").GetComponent<Image>();
        arasujiGamen.sprite = arasuji[0];
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            cnt++;
            if (cnt >= 8)
            {
                cnt = 7;
                SceneManager.LoadScene("TakayamaDebug");
            }
            arasujiGamen.sprite = arasuji[cnt];
        }
    }
}
