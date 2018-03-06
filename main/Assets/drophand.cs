using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class drophand : MonoBehaviour, IDropHandler{
    private Text text;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3n3;
    private GameObject star3;
    private GameObject star32;


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
        star3n3 = GameObject.Find("ggg");
        star3 = GameObject.Find("star3");
        star32 = GameObject.Find("2n2");
        
            if (!item && this.gameObject.tag == draghandler.itemdrag.tag   )
            {

                draghandler.itemdrag.transform.SetParent(transform);
                text = draghandler.itemdrag.GetComponent<Text>();
                text.color = Color.green;
            
        }
       else  if(item && this.gameObject.tag == draghandler.itemdrag.tag)
        {
          
            text = draghandler.itemdrag.GetComponent<Text>();
            text.color = Color.green;
        }
        else if (!item || item &&  this.gameObject.tag != draghandler.itemdrag.tag)
        {

            text = draghandler.itemdrag.GetComponent<Text>();
            text.color = Color.red;
            star3.GetComponent<Image>().enabled = false;

           /* if (!item || item && this.gameObject.tag != draghandler.itemdrag.tag)
            {
                text = draghandler.itemdrag.GetComponent<Text>();
                text.color = Color.red;
                star3n3.GetComponent<Image>().enabled = false;
                star32.GetComponent<Image>().enabled = true;
            }*/

        }
       



    }
    #endregion
}
