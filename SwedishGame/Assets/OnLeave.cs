using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnLeave : MonoBehaviour, IPointerExitHandler
{
    public GameObject countryImage;
    
    void Start()
    {
        PolygonCollider2D imageCollider = countryImage.GetComponent<PolygonCollider2D>();
    }
    

    public void OnPointerExit(PointerEventData imageCollider)
    {
        countryImage.SetActive(false);
    }
    
    public void HideImage()
    { 
         countryImage.SetActive(false);
    }
    
    
}
