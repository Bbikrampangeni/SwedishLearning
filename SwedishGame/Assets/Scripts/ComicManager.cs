using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicManager : MonoBehaviour {

    public GameObject canvas;
    public static Vector3 ZoomInPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ZoomIn.isClicked)
        {
            canvas.SetActive(true);
        }
	}
    public void BackPosition()
    {
        ZoomIn.isClicked = false;
        canvas.SetActive(false);
    }
}
