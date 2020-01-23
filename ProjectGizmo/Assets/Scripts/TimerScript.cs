using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float StartTime = 60;
    private float currentTime = 0;
    private float PauseTime;
    public Text timerSeconds;
    private bool isRunning = false;

  

    public GameObject gizmo;

    private void Start()
    {  
        Scene currentScene = SceneManager.GetActiveScene();
        currentTime = StartTime;
    }
    public void timerStart()
    {
        isRunning = true;
        gizmo.GetComponent<Rigidbody2D>().isKinematic = false;
        
    }
    
    public void timerRestart()
    {
        isRunning = false;

        if(SceneManager.GetActiveScene().buildIndex == 1)
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

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= 1 * Time.deltaTime;
            
        }
        timerSeconds.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
           currentTime = 0;
           timerEnded();
        }

    }

    
    private void timerEnded()
    {
      SceneManager.LoadScene(5); 
    }
}
