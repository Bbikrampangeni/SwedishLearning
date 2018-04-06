using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour {

    public GameObject PopUpCanvas;
    private bool isClick = false;

    private void Update()
    {
        if (isClick)
            PopUpCanvas.SetActive(true);
        else
            PopUpCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
            isClick = !isClick;
    }

    public void close()
    {
        isClick = false;
    }
}
