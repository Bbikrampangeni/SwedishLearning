using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paneltrigger : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void OnMouseDown()
    {
        canvas.SetActive(true);
    }
}
