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
        {
            DisplayText.SetActive(true);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        else
        {
            DisplayText.SetActive(false);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }

        
	}

    public void PointerEnter()
    {
        isPointerEnter = !isPointerEnter;
    }
    
   
}
