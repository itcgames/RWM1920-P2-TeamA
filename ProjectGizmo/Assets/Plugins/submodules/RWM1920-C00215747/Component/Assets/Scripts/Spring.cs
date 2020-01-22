using UnityEngine;
using System;
using System.Collections;

public class Spring : MonoBehaviour
{
    public float springForce = 1000;
    private Collision2D collision;
    private bool bouncing = false;
    private Animator animator;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < objects.Length; i++)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (!bouncing && !animator.GetBool("Pressing"))
                {
                    animator.SetBool("Pressing", true);
                    animator.SetBool("Releasing", false);
                    bouncing = true;
                    collision = coll;
                    audio.Play();
                }
            }
        }
    }

    void FixedUpdate()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects.Length);
            if (bouncing)
            {
                animator.SetBool("Pressing", false);
                animator.SetBool("Releasing", true);
                var rb = objects[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(new Vector2(0f, springForce));
                bouncing = false;

            }
        }
    }
    
}