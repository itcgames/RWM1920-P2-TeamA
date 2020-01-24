﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D firePoint;
    public Rigidbody2D rbPlayer;
    public Transform collide;

    public float maxDistance = 2.0f;
    public float releaseTime = 0.15f;

    public float ReloadTime = 5.0f;
    public float FireTime = 1.5f;
    public bool autoFire = false;
    private bool disableInput = false;


    public bool turretMode = true;

    private bool isPressed = false;
    private Vector2 autoFirePos;

    public bool placementMode = false;

    AudioSource source;


    void Start()
    {
        Physics2D.IgnoreCollision(collide.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        source = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (!turretMode)
        {
         
        }

        turret();

        if (!placementMode)
        {
            if (!disableInput)
            {
                movePayload(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (Input.GetKey(KeyCode.Q))
                {
                    print("Reload pressed");
                    Reload();
                }
            }
        }
    }

    void turret()
    {
        isPressed = true;
        //print("beep");
        OnMouseUp();
        turretMode = false;
    }

    void OnMouseDown()
    {
        if (!placementMode)
        {
            if (!disableInput)
            {
                isPressed = true;
                rb.isKinematic = true;
            }
        }
    }

    void OnMouseUp()
    {
        if (!placementMode)
        {
            if (!disableInput)
            {
                isPressed = false;
                rb.isKinematic = false;
                autoFirePos = rb.position;
                StartCoroutine(Release());
                //GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
        }
        else if (placementMode)
        {
            firePoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Reload();
            placementMode = false;
        }
    }


    void movePayload(Vector2 t_pos)
    {
        if (isPressed)
        {
            Vector2 mousePos = t_pos;

            if (Vector3.Distance(firePoint.position, mousePos) > maxDistance)
            {
                rb.position = firePoint.position + (mousePos - firePoint.position).normalized * maxDistance;
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }



    public void Reload()
    {
        StopCoroutine(Release());
        isPressed = false;
        rb.isKinematic = false;
        rb.position = firePoint.position;
        rb.velocity = Vector2.zero;
        GetComponent<SpringJoint2D>().enabled = true;
    }



    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;

        source.Play();

        //this.enabled = false;
        if (autoFire)
        {
            disableInput = true;
            StartCoroutine(ReloadWait());
        }
    }

    public IEnumerator ReloadWait()
    {
        Physics2D.IgnoreCollision(rbPlayer.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);


        yield return new WaitForSeconds(ReloadTime);
        Physics2D.IgnoreCollision(rbPlayer.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        Reload();
        if (autoFire)
        {
            StartCoroutine(FireWait());
        }
    }

    IEnumerator FireWait()
    {
        rb.position = autoFirePos;
        isPressed = true;
        rb.isKinematic = true;
        yield return new WaitForSeconds(FireTime);
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }
}
