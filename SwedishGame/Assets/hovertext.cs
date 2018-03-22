using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hovertext : MonoBehaviour {
    public GameObject gameobject;

    bool Pointer;
	// Use this for initialization
	void Start () {
        Pointer = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Pointer)
            gameobject.SetActive(true);
        else
            gameobject.SetActive(false);
	}

    public void PointerEnterExit()
    {
        Pointer = !Pointer;
    }
}
