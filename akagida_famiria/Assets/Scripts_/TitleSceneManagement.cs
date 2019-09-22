using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManagement : MonoBehaviour
{
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        AudioManager.Instance.PlayBGM("Title");
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameScene()
    {
        if (flag){
            flag = false;
            AudioManager.Instance.AttachBGMSource.Stop();
            AudioManager.Instance.PlaySE("TitleCall");
            Invoke("LoadArasujiScene", 3f);
        }
    }
    void LoadArasujiScene()
    {
        SceneManager.LoadSceneAsync("ArasujiScene");
    }
}
