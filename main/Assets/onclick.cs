using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour {
    public GameObject setting;

    bool isclick = false;
   public void OnMouseDown()
    {
        isclick = !isclick;

    }
    void Update()
    {

        if (isclick)
        {
            setting.gameObject.SetActive(true);
        }
        else
        {
           setting.gameObject.SetActive(false);
        }
    }
}
