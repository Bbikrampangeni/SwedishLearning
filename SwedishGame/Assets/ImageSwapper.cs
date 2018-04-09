using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwapper : MonoBehaviour {

    public Sprite[] sprites;
    public Image imageContainer;
    PlayerStats stats = PlayerStats.instance;

	// Use this for initialization
	void Start ()
    {
        if (stats.selectedGender == "male")
        {
            imageContainer.sprite = sprites[0];
        }
        else
        {
            imageContainer.sprite = sprites[1];
        }
	}
	
	
}
