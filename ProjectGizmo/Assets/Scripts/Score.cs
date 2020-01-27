using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score score;


    public float currentScore;

    public float finalScore;

    public Text scoreText;

    public bool isRunning = false;

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
        isRunning = false;
        DontDestroyOnLoad(this);
        if(score == null)
        {
            score = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentScore = 0;
            finalScore = 0;
            isRunning = false;
        }
 

        if (isRunning)
        {
            currentScore += 1 * Time.deltaTime;
           
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag("GizmoSprite");
        

        if (objects.Length > 0)
        {
            isRunning = false;
            currentScore = 0;
        }
        else
        {
            isRunning = true;
        }
        
        LevelEnded();


   

    }
   
    private void LevelEnded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 9|| SceneManager.GetActiveScene().buildIndex == 7)
        {
            finalScore = finalScore + currentScore;
            isRunning = false;
            currentScore = 0;
            scoreText.text = "Score: " + finalScore.ToString("0");
        }
        else
        {
            scoreText.text = "     ";
        }
    }

}


