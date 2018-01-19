using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

    public Button bankB;
    public Button carB;
    public Button backB;

    int money = 0;

    public GameObject carDealer;
    public GameObject bank;
    public Camera mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToBank()
    {
        mainCamera.transform.position = new Vector3(carDealer.transform.position.x, carDealer.transform.position.y,carDealer.transform.position.z);
        bankB.enabled = false;
        carB.enabled = false;
        backB.enabled = true;
        money = 10000;
    }

    public void GoToCar()
    {
        mainCamera.transform.position = new Vector3(bank.transform.position.x, bank.transform.position.y, bank.transform.position.z);
        bankB.enabled = false;
        carB.enabled = false;
        backB.enabled = true;
        if (money == 10000)
        {
            SceneManager.LoadScene("Finland");
        }
        else
        {
            Debug.Log("No MONEY");
        }
    }

    public void GoBack()
    {
        mainCamera.transform.position = new Vector3(0, 0, 0);
        bankB.enabled = true;
        carB.enabled = true;
        backB.enabled = false;
    }
}
