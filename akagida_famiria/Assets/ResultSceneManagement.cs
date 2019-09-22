using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManagement : MonoBehaviour
{

    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = Mathf.FloorToInt(GameManagement.score).ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackGameScene()
    {
        AudioManager.Instance.AttachBGMSource.Stop();
        //AudioManager.Instance.PlaySE("TitleCall");
        GameManagement.stage = 1;
        GameManagement.score = 8.0f;
        SceneManager.LoadScene("TakayamaDebug");
    }

    public void BackTitleScene()
    {
        AudioManager.Instance.AttachBGMSource.Stop();
        //AudioManager.Instance.PlaySE("TitleCall");
        GameManagement.stage = 1;
        GameManagement.score = 8.0f;
        Destroy(AudioManager.Instance.gameObject);
        SceneManager.LoadSceneAsync("TitleScene");
    }

    void LoadMainScene()
    {
        Time.timeScale = 1f;
        Destroy(AudioManager.Instance.gameObject);
        SceneManager.LoadSceneAsync("TitleScene");
    }
}
