using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static float score;
    private GameObject player;
    Text scoreText;

    //敵
    public static float enemyBulletSpeed = -10f;
    private GameObject enemyHPBar;
    private GameObject enemyTensionBar;

    private bool burstFlag;

    // Start is called before the first frame update
    void Start()
    {
        score = 8.0f;
        player = GameObject.Find("Player");
        scoreText = GameObject.Find("TextScore").GetComponent<Text>();

        enemyHPBar = GameObject.Find("Healthbar");
        enemyTensionBar = GameObject.Find("Manabar");
        enemyHPBar.GetComponent<Image>().fillAmount = 1;
        enemyTensionBar.GetComponent<Image>().fillAmount = 0;

        burstFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
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

    void ShowScore()
    {
        scoreText.text = "消費税\n" + Mathf.FloorToInt(score).ToString() +" %";
    }

    public void ChangeEnemyBar(float value)
    {
        enemyHPBar.GetComponent<Image>().fillAmount = value;
        enemyTensionBar.GetComponent<Image>().fillAmount += 0.05f;

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
