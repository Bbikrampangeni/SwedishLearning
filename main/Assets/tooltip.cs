using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tooltip : MonoBehaviour {
    [Header("object info")]

    public string objectname;
    [TextArea]
    public string objectInfo;
    [Header("display the info")]
    public GameObject tooltipwindow;
    public Text displayname;
    public Text displayInfo;

     void OnMouseEnter()
    {
        tooltipwindow.SetActive(true);
        if (tooltipwindow !=null)
        {
            displayname.text = objectname;
            displayInfo.text = objectInfo;
        }

       
    }

    void OnMouseExit()
    {
        tooltipwindow.SetActive(false);
    }

}
