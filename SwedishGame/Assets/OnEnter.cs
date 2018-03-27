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
    }
    
}
