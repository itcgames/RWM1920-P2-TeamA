using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGoalDetection : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col2D)
    {

        //Check for player collision
        if (col2D.gameObject.tag == "Player")
        {
            Debug.Log("win");
        }
    }

}
