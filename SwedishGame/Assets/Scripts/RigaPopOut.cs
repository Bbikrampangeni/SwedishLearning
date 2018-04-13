using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RigaPopOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image rigaImage;
    bool rigaEnabled = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rigaEnabled == true)
        {
            rigaImage.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rigaImage.transform.localScale = new Vector3(1, 1, 1);
    }

    void Start()
    {
        if (PlayerStats.instance.playerStars > 4)
        {
            rigaEnabled = true;
        }
    }

    public void RigaShowButtonCheat()
    {
        if (PlayerStats.instance.playerStars > 4)
        {
            rigaEnabled = true;
        }
    }

    public void Cheat()
    {
        PlayerStats.instance.playerStars = 8;
    }

    
}
