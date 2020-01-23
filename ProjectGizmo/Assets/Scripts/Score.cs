using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score score;


    public float currentScore;

    float finalScore;

    public Text scoreText;

    private bool isRunning = false;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentScore = 0;
    }

    public void scoreStart()
    {
        isRunning = true;
    }

    public void scoreRestart()
    {
        isRunning = false;
        currentScore = 0;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(3);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(4);
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(5);
        }

    }

    void Awake()
    {
        score = this;
        Debug.Log(currentScore);
        isRunning = false;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(isRunning)
        {
            currentScore += 1 * Time.deltaTime;

        }
        finalScore = finalScore + currentScore;
       
        
        //if(currentScore == 60||currentScore == 120||currentScore==180||currentScore ==240)
        //{
            LevelEnded();
            //currentScore = 0;
        //}


    }
   
    private void LevelEnded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 7)
        {
            isRunning = false;
            scoreText.text = "Score: " + finalScore.ToString("0");

        }
        else
        {
            scoreText.text = "     ";
        }
    }
    
}


