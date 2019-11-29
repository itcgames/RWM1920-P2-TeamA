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


    public bool disable = false;

    private bool jump = false;
    private float jumpspeed = 0f;

    private SpriteRenderer mySpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (jump == false)
                {
                    jump = true;
                    jumpspeed = jumpHeight;
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


    void OnCollisionEnter2D(Collision2D col)
    {
        if (!disable)
        {
            if (col.gameObject.tag == "Catapult")
            {
                disable = true;
                print("Collide");
            }
            else
            {
                if (col.gameObject.tag == "BorderSide")
                {
                    var direction = transform.InverseTransformPoint(col.transform.position);

                    if (direction.x > 0f || direction.x < 0f)
                    {
                        movementDirection = !movementDirection;
                        mySpriteRenderer.flipX = movementDirection;
                    }

                    print("Side Hit");
                }

                if (col.gameObject.tag == "BorderTop")
                {
                    jump = false;
                    print("top Hit");
                }
            }
        }
        else
        {
            if (rbPayload.GetComponent<SpringJoint2D>().enabled == false)
            {
                if (col.gameObject.tag == "BorderSide" || col.gameObject.tag == "BorderTop")
                {
                    print("Not disabled");
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
