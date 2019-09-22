using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameScene()
    {
        AudioManager.Instance.AttachBGMSource.Stop();
        AudioManager.Instance.PlaySE("TitleCall");
        Invoke("LoadScene", 3f);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("ArasujiScene");
    }
}
