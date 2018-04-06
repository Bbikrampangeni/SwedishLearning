using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour {

    public GameObject SettingPanel;
    bool IsSettingPress;

	// Use this for initialization
	void Start () {
        IsSettingPress = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsSettingPress)
        {
            SettingPanel.SetActive(true);
        }
        else
        {
            SettingPanel.SetActive(false);
        }
	}

    public void ToggleButton()
    {
        IsSettingPress = !IsSettingPress;
    }
}
