using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public int index;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void NextGame()
    {
        float waitTime = 4;
        float counter = 0;
        while( counter < waitTime)
        {
            counter += Time.deltaTime;
            Debug.Log(counter);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        float waitTime = 4;
        float counter = 0;
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            Debug.Log(counter);
        }

        index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        float waitTime = 4;
        float counter = 0;
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            Debug.Log(counter);
        }

        SceneManager.LoadScene("Win");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(index);
    }
}
