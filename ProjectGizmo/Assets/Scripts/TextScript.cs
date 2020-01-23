using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text message;
    Vector3 pos;
    private bool isCoroutineExecuting = false;
    static int count = 0;

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
    }

    // Update is called once per frame
    public static int tutorial(int x)
    {
        x = count;
        return x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ExecuteAfterTime(10);
            count += 1;
        }

        if(count == 0)
        {
            pos.x = 23.8f;
            pos.y = 14.4f;
            message.transform.position = pos;

            Buttons();
        }
        else if(count == 1)
        {
            Quit();
        }
        else if (count == 2)
        {
            Play();
        }
        else if (count == 3)
        {
            Restart();
        }
        else if (count == 4)
        {
            pos.x = 7.5f;
            message.transform.position = pos;
            Timer();
        }
        else if (count == 5)
        {
            pos.x = -17.4f;
            pos.y = 5.5f;
            message.transform.position = pos;
            Components();
        }
        else
        {
            pos.x = -17.4f;
            pos.y = -8.1f;
            message.transform.position = pos;
            Player();
        }
        
    }

    void Buttons()
    {
        ExecuteAfterTime(10);
        message.text = "These buttons are quit, play and restart.";
    }

    void Quit()
    {
        ExecuteAfterTime(10);
        message.text = "Quit allows you to exit the game or tutorial and returns you back to the Main Menu.";
    }

    void Play()
    {
        ExecuteAfterTime(10);
        message.text = "Play start the game along with the timer when you are ready. It is used to also play any extra components you have added to the game while playing.";
    }

    void Restart()
    {

        ExecuteAfterTime(10);
        message.text = "Restart refreshes the stage so that you can try again. it also rests the timer.";
    }

    void Timer()
    {
        ExecuteAfterTime(10);
        message.text = "This is the timer. You must complete each stage before the timer reaches zero otherwise it is game over.";
    }

    void Components()
    {
        ExecuteAfterTime(10);
        message.text = "These are the game components. They can be dragged and dropped onto the game screen to help the player reach the goal.";
    }

    void Player()
    {
        ExecuteAfterTime(10);
        message.text = "In order to win, you need to get the player, Gizmo, to the computer. Try getting him to jump over the obstacles by tapping the screen.";
    }

}
