﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonRiga : MonoBehaviour {

    public Image rigaImage;
    PlayerStats starStats = PlayerStats.instance;

	// Use this for initialization
	void Start () {
        if (starStats.playerStars >= 8)
        {
           Color rigaImageUnfaded = rigaImage.color;
           rigaImageUnfaded.a = 1f;
           rigaImage.color = rigaImageUnfaded; 
            
        }
	}
    // For testing only
    /*
    public void ShowRigaCheat()
    {
        if (starStats.playerStars > 4)
        {
            Color rigaImageUnfaded = rigaImage.color;
            rigaImageUnfaded.a = 1f;
            rigaImage.color = rigaImageUnfaded;

        }
    }
	*/
	
}
