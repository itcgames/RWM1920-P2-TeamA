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
    private GameObject ItemDrag;



    private void Start()
    {
        ImageStartPosition = pos.position;
    }
    public void Update()
    {
        if (dragging)
        {
            //   Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            ItemDrag.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
           // Debug.Log(transform.position);

        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
      //  transform.position = ImageStartPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ItemDrag = Instantiate(Item, new Vector2((clickedPosition.x), (clickedPosition.y)), Quaternion.identity);

    }
}
