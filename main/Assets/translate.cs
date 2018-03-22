using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translate : MonoBehaviour
{

    public GameObject gameobject;

    bool Pointer;
    // Use this for initialization
    void Start()
    {
        Pointer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pointer)
        {
            gameobject.SetActive(true);

        }
        else
            gameobject.SetActive(false);

    }

    public void PointerEnterExit()
    {
       
        #pragma warning disable CS0665 // Assignment in conditional expression is always constant
                if (Pointer=true)
        #pragma warning restore CS0665 // Assignment in conditional expression is always constant
                {
                    starmanger.Star -= 1.00f;
      
                }

    }
   
}
