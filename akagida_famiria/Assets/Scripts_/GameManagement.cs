using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static float score=8.0f;
    public static int stage = 1;
    private GameObject player;
    private GameObject enemy;
    Text scoreText;

    //敵
    public static float enemyBulletSpeed = -10f;
    private GameObject enemyHPBar;
    private GameObject enemyTensionBar;
    public GameObject enemyHPText;
    public Sprite[] enemyBarSprites;
    public GameObject enemyBarFrame;

    private bool burstFlag;

    //PauseUI
    public GameObject pauseUI;
    public GameObject pauseButtonText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        player = GameObject.Find("Player");

        AudioManager.Instance.PlayBGM("BGM"+stage.ToString());

        //STAGEによって場合分けしてEnemyをインスタンス化
        enemy = GameObject.Find("MikamiTEKI");

        scoreText = GameObject.Find("TextScore").GetComponent<Text>();

        enemyHPBar = GameObject.Find("Healthbar");
        enemyTensionBar = GameObject.Find("Manabar");
        enemyHPBar.GetComponent<Image>().fillAmount = 1;
        enemyTensionBar.GetComponent<Image>().fillAmount = 0;
        enemyHPText.GetComponent<Text>().text = enemy.GetComponent<Enemy>().GetMaxHP().ToString();
        enemyBarFrame.GetComponent<Image>().sprite = enemyBarSprites[Mathf.Min(2,stage-1)];

        burstFlag = true;

        Debug.Log("STAGE:" + stage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        ShowScore();
        if (enemy.GetComponent<Enemy>().Defeat() && !pauseUI.gameObject.activeSelf)
        {
            AudioManager.Instance.AttachBGMSource.Stop();
            AudioManager.Instance.PlaySE("Children");
            pauseUI.SetActive(true);
            if (stage >= 3)
            {
                pauseButtonText.GetComponent<Text>().text = "RESULT";
            }
            Time.timeScale = 0f;
        }
    }

    public void NextStage()
    {
        pauseUI.SetActive(false);

        AudioManager.Instance.AttachSESource.Stop();
        stage++;
        if (stage < 4)
        {
            SceneManager.LoadScene("TakayamaDebug");
        }
        else
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
    public void CalScore(float num)
    {
        score += num;
        if (score <= 0)
        {
            score = 0;
        }else if(score >= 100)
        {
            score = 100;
        }
    }

    public float GetScore()
    {
        return score;
    }

    void ShowScore()
    {
        scoreText.text = "消費税\n" + Mathf.FloorToInt(score).ToString() +" %";
    }

    public void ChangeEnemyBar(float value)
    {
        enemyHPBar.GetComponent<Image>().fillAmount = value;
        enemyTensionBar.GetComponent<Image>().fillAmount += 0.08f;

        if(enemyTensionBar.GetComponent<Image>().fillAmount>=1 && burstFlag)
        {
            burstFlag = false;
            enemyBulletSpeed *= 2;
            Invoke("ReChangeEnemyBulletSpeed", 10);
        }
    }

    void ReChangeEnemyBulletSpeed()
    {
        enemyBulletSpeed /= 2;
        burstFlag = true;
        enemyTensionBar.GetComponent<Image>().fillAmount = 0;
    }
}
