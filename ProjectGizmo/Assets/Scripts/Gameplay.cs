using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject player;

    public GameObject fan;
    public GameObject bubble;
    public GameObject catapult;
    public GameObject spring;
    public GameObject belt;




    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void startGame()
    {
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
           
            if(g.tag == "GizmoSprite")
            {
                Destroy(g);
                Instantiate(player, g.transform.position, g.transform.rotation);
            }

            if (g.tag == "CatapultSprite")
            {
               // Destroy(g);
               // Instantiate(catapult, g.transform.position, g.transform.rotation);
            }
            if (g.tag == "BeltSprite")
            {
                Destroy(g);
                Instantiate(belt, g.transform.position, g.transform.rotation);
            }
            if (g.tag == "FanSprite")
            {
                Destroy(g);
                Instantiate(fan, g.transform.position, g.transform.rotation);
            }
            if (g.tag == "SpringSprite")
            {
                Destroy(g);
                Instantiate(spring, g.transform.position, g.transform.rotation);
            }
            if (g.tag == "BubbleSprite")
            {
                Destroy(g);
                Instantiate(bubble, g.transform.position, g.transform.rotation);
            }

        }
    }
}
