using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class drophand : MonoBehaviour, IDropHandler{
    private Text text;
    public static int correctAnswers = 0;
   


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
                correctAnswers++;

           
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log(correctAnswers);
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
            starmanger.Star -= 0.25f;
            if (draghandler.itemdrag.tag!=this.gameObject.tag && this.gameObject.tag== null)
            {
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
           



        }
       



    }
    #endregion
}
