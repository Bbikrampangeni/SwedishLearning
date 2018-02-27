using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayButton : MonoBehaviour {

    public GameObject DisplayText;

    private bool isPointerEnter;

	// Use this for initialization
	void Start () {
        isPointerEnter = false;
	}
	
	void Update () {
        if (isPointerEnter)
            DisplayText.SetActive(true);
        else
            DisplayText.SetActive(false);
	}

    public void PointerEnter()
    {
        isPointerEnter = !isPointerEnter;
    }
    
   
}
