using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;







public class ClickDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    private Vector3 ImageStartPosition;
    public RectTransform pos;
    public GameObject Item;


    private void Start()
    {
        ImageStartPosition = pos.position;
    }
    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        transform.position = ImageStartPosition;
       
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(Item, new Vector2( (clickedPosition.x), (clickedPosition.y)), Quaternion.identity);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }
}
