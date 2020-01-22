using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbPayload;

    public float releaseTime = 1.0f;

    private bool firePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rbPayload.GetComponent<SpringJoint2D>().enabled == false)
        {
            StartCoroutine(Release());
        }

        if (firePlayer)
        {
            rbPlayer.position = rbPayload.position;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            firePlayer = true;
        }
    }


    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        firePlayer = false;
    }
}
