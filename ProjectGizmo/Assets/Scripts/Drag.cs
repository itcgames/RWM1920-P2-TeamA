using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float m_coordinates;
    private Vector3 m_Offset;
    private bool playing = false;

    private void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GizmoSprite");

        if (objects.Length > 0)
        {
            playing = false;
        }
        else
        {
            playing = true;
        }
    }
    void OnMouseDown()
    {
        if (playing == false)
        {
            m_coordinates = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            m_Offset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }

    void OnMouseDrag()
    {
        if (playing == false)
        {
            transform.position = GetMouseAsWorldPoint() + m_Offset;
        }
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        if (playing == false)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = m_coordinates;
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        return gameObject.transform.position;
    }


}
