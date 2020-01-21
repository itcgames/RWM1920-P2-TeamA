using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text message;
    Vector3 pos;
    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        isCoroutineExecuting = false;
    }

    void Start()
    {
        message = gameObject.GetComponent<Text>();
        message.text = "These buttons are quit, play and restart.";
        pos = message.transform.position;
        StartCoroutine(ExecuteAfterTime(10));
        /* quit = gameObject.GetComponent<Text>();
                quit.gameObject.SetActive(false);
                play = gameObject.GetComponent<Text>();
                play.gameObject.SetActive(false);
                timer = gameObject.GetComponent<Text>();
                timer.gameObject.SetActive(false);
                restart = gameObject.GetComponent<Text>();
                restart.gameObject.SetActive(false);
                components = gameObject.GetComponent<Text>();
                components.gameObject.SetActive(false);
                player = gameObject.GetComponent<Text>();
                player.gameObject.SetActive(false);*/
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);
            pos.x = 15.8f;
            pos.y = 12.4f;
            message.transform.position = pos;
            Buttons();
        }
    }

    void Buttons()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);
            message.text = "Quit allows you to exit the game or tutorial and returns you back to the Main Menu.";
            // quit.gameObject.SetActive(true);
            Quit();
        }
    }

    void Quit()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);
            message.text = "Play start the game along with the timer when you are ready. It is used to also play any extra components you have added to the game while playing.";
            
            
            /*quit.gameObject.SetActive(false);
            play.gameObject.SetActive(true);*/
            Play();
        }
    }

    void Play()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);

            message.text = "Restart refreshes the stage so that you can try again. it also rests the timer.";
            /*play.gameObject.SetActive(false);
                    restart.gameObject.SetActive(true);*/
            Restart();
        }
    }

    void Restart()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);

            message.text = "This is the timer. You must complete each stage before the timer reaches zero otherwise it is game over.";
            pos.x = -5.5f;
            message.transform.position = pos;
            /*restart.gameObject.SetActive(false);
                    timer.gameObject.SetActive(true);*/
            Timer();
        }
    }

    void Timer()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);

            message.text = "These are the game components. They can be dragged and dropped onto the game screen to help the player reach the goal.";
            pos.x = -25.4f;
            pos.y = 5.5f;
            message.transform.position = pos;
            /*timer.gameObject.SetActive(false);
                    components.gameObject.SetActive(true);*/
            Components();
        }
    }

    void Components()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);

            message.text = "In order to win, you need to get the player, Gizmo, to the computer. Try getting him to jump over the obstacles by pressing the 'Spacebar'.";
            pos.x = -17.4f;
            pos.y = -8.1f;
            message.transform.position = pos;
            /*components.gameObject.SetActive(false);
                                player.gameObject.SetActive(true);*/
            Player();
        }
    }

    void Player()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            ExecuteAfterTime(10);
            
            //player.gameObject.SetActive(false);
        }
    }
}
