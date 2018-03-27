using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnEnter : MonoBehaviour, IPointerEnterHandler
{
    public GameObject latviaImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        latviaImage.SetActive(true);
        Debug.Log("Entering the latvia trigger");
    }

    public void OnMouseOver()
    {
        Debug.Log(gameObject.name);
    }
}
