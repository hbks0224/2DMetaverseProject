using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI StartText;
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

   public int currentScore = 0;
    UIManager uiManager;


    public UIManager UIManager { get { return uiManager; } } //이거 왜 ?



    public void Awake()
    {
        gameManager = this;
        uiManager = FindAnyObjectByType<UIManager>();
        uiManager.UpdateScore(0);

        
    }

    private void Start()
    {
        Time.timeScale = 0f; //시작하자마 정지
        StartText.gameObject.SetActive(true);


    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            StartText.gameObject.SetActive(false);

        }
    }

    public void GameOver()
    {
        uiManager.SetRestart();
        Debug.Log("Game Over");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainScene");


    }

    public void AddScore(int score)
    {

        currentScore += score;
        Debug.Log($"Score {currentScore}");
        uiManager.UpdateScore(currentScore);
    }


}
