using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour {

    public static int PlayerChoice;

    private void Start()
    {
        GetComponentInChildren<Text>().color = Color.cyan;
    }
    public void Toggle()
    {
        PlayerChoice = transform.GetSiblingIndex();
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Option"))
        {
            if(go != gameObject)
                go.GetComponentInChildren<Text>().color = Color.cyan;
        }
        GetComponentInChildren<Text>().color = Color.yellow;        
    }
}
