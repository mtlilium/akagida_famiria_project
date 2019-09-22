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
        AudioManager.Instance.PlayBGM("ArasujiBGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && cnt < 7)
        {
            cnt=Mathf.Min(7,cnt+1);
            AudioManager.Instance.PlaySE("Button");
            if (cnt == 7 && AudioManager.Instance.AttachBGMSource.isPlaying)
            {
                AudioManager.Instance.AttachBGMSource.Stop();
                AudioManager.Instance.PlaySE("Impact");
                Invoke("LoadGameScene", 5f);
            }
            /*if (cnt >= 8)
            {
                cnt = 7;
                SceneManager.LoadScene("TakayamaDebug");
            }*/
            arasujiGamen.sprite = arasuji[cnt];
        }
    }

    void LoadGameScene()
    {
        SceneManager.LoadSceneAsync("TakayamaDebug");
    }
}
