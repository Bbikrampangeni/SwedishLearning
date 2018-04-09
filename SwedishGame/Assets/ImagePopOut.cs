using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImagePopOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image cityImage;


    public void OnPointerEnter(PointerEventData eventData)
    {
        cityImage.transform.localScale = new Vector3(2, 2, 2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cityImage.transform.localScale = new Vector3(1, 1, 1);
    }
}
