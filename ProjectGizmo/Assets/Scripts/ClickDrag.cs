using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;







public class ClickDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    public RectTransform pos;
    public GameObject Item;
    private GameObject ItemDrag;

    private bool playing = false;




    private void Start()
    {     
        
       
    }
    public void Update()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("GizmoSprite");

        if (dragging)
        {
            ItemDrag.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        }

        if(objects.Length > 0)
        {
            playing = true;
        }
        else
        {
            playing = false;
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playing == true)
        {
            dragging = true;
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ItemDrag = Instantiate(Item, new Vector2((clickedPosition.x), (clickedPosition.y)), Quaternion.identity);
        }
    }
}
