using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMusicLoop : MonoBehaviour
{
    private void Awake()
    {
        GameObject objs = GameObject.FindGameObjectWithTag("MusicLoop");
        if (objs != null)
        {
            Destroy(objs);
        }
    }
}
