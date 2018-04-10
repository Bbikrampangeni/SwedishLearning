using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour {

    public Camera mainCam;
    public GameObject intoBank;
    public GameObject talk;

    Button intoBankButton; 
    Button talkButton; 

    private void Start()
    {
        intoBankButton = intoBank.GetComponent<Button>();
        talkButton = talk.GetComponent<Button>();
    }

    void GoInsideBank()
    {
        mainCam.transform.position = new Vector3(-19, 0, -10);
        intoBank.SetActive(false);
        talk.SetActive(true);

    }
	
}
