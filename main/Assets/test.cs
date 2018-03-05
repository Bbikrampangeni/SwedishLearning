using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject canvas;

    bool isclick = false;
    void OnMouseDown()
    {
        isclick = !isclick;

    }
    void Update()
    {

        if (isclick)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
    
}
