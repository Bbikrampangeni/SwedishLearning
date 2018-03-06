using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public GameObject playButtonContainer;
    public GameObject latviaButtonContainer;
    bool isActive;

    public void ShowPlayButton()
    {
        playButtonContainer.SetActive(true);
    }
	
}
