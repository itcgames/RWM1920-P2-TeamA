using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbPayload;
    public bool movementDirection = false;
    public float speed = 0;
    public float jumpHeight = 0;

    private bool bottomHit = false;

    public bool disable = false;

    private bool jump = false;
    private float jumpspeed = 0f;

    private SpriteRenderer mySpriteRenderer;

    public AudioSource [] source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponents<AudioSource>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
       
        //source[1].Play();

        if (!disable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!bottomHit)
                {
                    if (jump == false)
                    {
                        source[1].Play();
                        jump = true;
                        jumpspeed = jumpHeight;
                    }
                }
            }

            if (jump)
            {
                rb.position += movementDirection ? new Vector2(speed, jumpspeed) : new Vector2(-speed, jumpspeed);
                jumpspeed *= 0.9f;
                if (jumpspeed <= 0)
                {
                    jumpspeed = 0;
                }
            }
            else
            {
                rb.position += movementDirection ? new Vector2(speed, 0) : new Vector2(-speed, 0);
            }
        }
    }

    public void setBottomHit(bool t_bool)
    {
        bottomHit = t_bool;
    }

    public void setJump(bool t_bool)
    {
        jump = t_bool;
    }


    public void directionChange()
    {
       movementDirection = !movementDirection;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (!disable)
        {
            if (col.gameObject.tag == "Catapult")
            {
               // disable = true;
            }
            else
            {
                if (col.gameObject.tag == "BorderBottom")
                {
                    bottomHit = true;
                }

                if (!bottomHit)
                {
                    if (col.gameObject.tag == "BorderSide")
                    {
                        source[0].Play();
                        var direction = transform.InverseTransformPoint(col.transform.position);

                        if (direction.x > 0f || direction.x < 0f)
                        {
                       
                            movementDirection = !movementDirection;
                            mySpriteRenderer.flipX = movementDirection;
                        }
                    }
                }
                if (col.gameObject.tag == "BorderTop")
                {
                    jump = false;
                    bottomHit = false;
                }
            }
        }
        else
        {
            if (rbPayload.GetComponent<SpringJoint2D>().enabled == false)
            {
                if (col.gameObject.tag == "BorderSide" || col.gameObject.tag == "BorderTop")
                {
                    disable = false;
                    rb.isKinematic = false;
                    StartCoroutine(rbPayload.GetComponent<Payload>().ReloadWait());
                }
                else
                {
                    rb.isKinematic = true;
                    rb.position = rbPayload.position;
                }
            }
        }
    }
}
