using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour {

    public GameObject textContainer;
    Text text;
	// Use this for initialization
	void Start () {
        textContainer = GameObject.Find("StarCount");
        text = textContainer.GetComponent<Text>();
        text.text = PlayerStats.instance.playerStars.ToString();
 	}
	
	
}
