using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class foodstarcounter : MonoBehaviour
{

    public GameObject StarObject;
    public GameObject StarPrefab;
    private EventSystem system;
    public static bool isreplay;
    public GameObject FinalResult;
    public static bool isFinalChecked;
    public static float Star = 3;
    public GameObject popup;
    private void Start()
    {

        isFinalChecked = false;
        isreplay = false;
    }
    void Update()
    {

        displayStarScore();
        if (Star < 1)
        {
            popup.SetActive(true);
        }
        if (isreplay)
        {
            Star = 3;



        }

    }
    private void displayStarScore()
    {
        float quaterOfStar = Star / 0.25f;
        GameObject starScore = GameObject.Find("StarScorePanel");

        for (int i = (int)quaterOfStar; i < 12; i++)
        {
            if (starScore != null)
                starScore.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;       //set color for empty star
        }

        for (int i = 0; i < quaterOfStar; i++)
        {
            if (starScore != null)
                starScore.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.black;
        }
    }
    public void FinalCheck()
    {
        if (Star % (int)Star == 0.75f)          //round the score
            Star = Star + 0.25f;
        else
            Star = (int)Star;
        isFinalChecked = true;
    }
}




