using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_drag_drop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Drag()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject.Find("Text"+ i).transform.position = Input.mousePosition;

        }
      
    }
}
