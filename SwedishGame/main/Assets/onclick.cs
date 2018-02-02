using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour {
    public GameObject image;

    bool isclick = false;
    void OnMouseDown()
    {
        isclick = !isclick;

    }
    void Update()
    {

        if (isclick)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }
}
