using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonRiga : MonoBehaviour {

    public GameObject rigaButton;
    PlayerStats starStats = PlayerStats.instance;

	// Use this for initialization
	void Start () {
        if (starStats.playerStars > 4)
        {
            rigaButton.SetActive(true);
        }
	}
	
	
}
