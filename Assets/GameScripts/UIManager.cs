using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    Player player;
    GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI LoseText;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI targetScoreText;
    public int targetScore = 5;
    public int bestScore = 0;
    private bool isTarget = false;
    // Start is called before the first frame update
    void Start()
    {

         PlayerPrefs.DeleteAll();

        if (restartText == null)
        {

            Debug.LogError("restart text is null");
        }
        if (scoreText == null)
        {

            Debug.LogError("score text is null");
        }
        if (bestScoreText == null)
        {

            Debug.LogError("score text is null");
        }
        restartText.gameObject.SetActive(false); //오브젝트를 끔

        bestScore = PlayerPrefs.GetInt("BestScore",0);
        targetScore = PlayerPrefs.GetInt("TargetScore", 5);
        bestScoreText.text = bestScore.ToString();
        targetScoreText.text = targetScore.ToString();

    }



    public void SetRestart()
    {
        //if (GameManager.currentScore >= targetScore) // 이거로하면 점수 달성한 시점에 타겟스코어도 올라가서 절대 성립안됨
        //{

        //    restartText.gameObject.SetActive(true);
        //    WinText.gameObject.SetActive(true);
        //}

        //else
        //{

        //    restartText.gameObject.SetActive(true);
        //    LoseText.gameObject.SetActive(true);

        //}

        if (isTarget == true) // 이거로하면 점수 달성한 시점에 타겟스코어도 올라가서 절대 성립안됨
        {

            restartText.gameObject.SetActive(true);
            WinText.gameObject.SetActive(true);
        }

        else
        {

            restartText.gameObject.SetActive(true);
            LoseText.gameObject.SetActive(true);

        }


    }
    public void UpdateScore(int score)
    {

        //scoreText.text = score.ToString();
        

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = bestScore.ToString() ;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
        
        if(score >= targetScore)
        {
            
            isTarget = true; // 이거로 조건문 처리해야함 
            targetScore += 5;
            targetScoreText.text = targetScore.ToString() ;
            PlayerPrefs.SetInt("TargetScore",targetScore);
           
            PlayerPrefs.Save();

        }
        
    }
}
