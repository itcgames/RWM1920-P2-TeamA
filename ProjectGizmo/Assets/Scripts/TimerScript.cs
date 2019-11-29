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

    private Scene scene;


    private void Start()
    {
        currentTime = StartTime;
    }
    public void timerStart()
    {
        isRunning = true;
    }
    public void timerPause()
    {
        isRunning = false;
    }
    public void timerRestart()
    {
        isRunning = false;
        currentTime = StartTime;
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
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.LoadScene("GameOver", parameters);
        print ("hi");
    }
}
