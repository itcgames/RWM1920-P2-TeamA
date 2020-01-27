﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    int index = 1;

    void OnTriggerEnter2D(Collider2D col2D)
    {
        if (col2D.gameObject.tag == "Player")
        {
            Debug.Log("Win");
            Win();
        }
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(index);
    }

    public void StartGame()
    {
        index = 2;
        SceneManager.LoadScene(index);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("StartGame");
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
        index = PlayerPrefs.GetInt("Score");
        if (index + 1 > 5)
        {
            PlayerPrefs.SetInt("Score", 1);
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            SceneManager.LoadScene(index + 1);
        }
    }

    public void EndGame()
    {
        float waitTime = 4;
        float counter = 0;
        while (counter < waitTime)
        {
            counter += Time.deltaTime;

        }

        SceneManager.LoadScene(0);
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

        PlayerPrefs.SetInt("Score", SceneManager.GetActiveScene().buildIndex);
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
        Debug.Log(index);
        PlayerPrefs.SetInt("Score", SceneManager.GetActiveScene().buildIndex);
        if (index < 4)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public void ReplayGame()
    {
        index = PlayerPrefs.GetInt("Score");
        SceneManager.LoadScene(index);
    }
}
