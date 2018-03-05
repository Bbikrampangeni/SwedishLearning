using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class drophand : MonoBehaviour, IDropHandler{
    private Text text;
    
    public GameObject item
    {
get
        {
            if (transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    #region IdropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
       
        
            if (!item && this.gameObject.tag == draghandler.itemdrag.tag   )
            {

                draghandler.itemdrag.transform.SetParent(transform);
                text = draghandler.itemdrag.GetComponent<Text>();
                text.color = Color.green;

        }
        else if (!item && this.gameObject.tag != draghandler.itemdrag.tag)
        {
            draghandler.itemdrag.transform.SetParent(transform);
            text = draghandler.itemdrag.GetComponent<Text>();
            text.color = Color.red;
        }
       


    }
    #endregion
}
