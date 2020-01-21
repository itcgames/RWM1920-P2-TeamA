using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    //public float duration;

    private bool direction = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     

        if (direction)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0);
            //transform.position += new Vector3(0.005f, 0.005f, 0);

            if (transform.localScale.x > 2.7)
            {
                direction = !direction;
            }
        }
        else
        {
            transform.localScale -= new Vector3(0.001f, 0.001f, 0);
            //transform.position -= new Vector3(0.005f, 0.005f, 0);

            if (transform.localScale.x < 2.55)
            {
                direction = !direction;
            }
        }

        /*
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;
        float R = amplitude;
        float G = amplitude;
        float B = amplitude;

        Material mat = GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", new Color(R, G, B));
        */
    }
}
