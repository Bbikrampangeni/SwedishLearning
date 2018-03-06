using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class draghandler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
    private  Text text;
    public static GameObject itemdrag;
    Vector3 startposition;
    Transform startparent;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemdrag = gameObject;
        startposition = transform.position;
        startparent = transform.parent;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        /*if ( this.gameObject == startparent && this.gameObject.tag != itemdrag.tag)
        {
            text.color = Color.red;
        }*/
        if (this.gameObject == startparent&&this.gameObject.tag == itemdrag.tag)
        {
            text.color = Color.green;
           
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemdrag = null;

        if (transform.parent== startparent )
        {
            transform.position = startposition;

  

        }
    





    }


}
