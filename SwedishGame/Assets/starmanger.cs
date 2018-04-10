using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class starmanger : MonoBehaviour
{

    PlayerStats starStats = PlayerStats.instance;
    public GameObject StarObject;
    public GameObject StarPrefab;
    private EventSystem system;
    public static bool isreplay;
    public GameObject FinalResult;
    public static bool isFinalChecked;
    public static float Star = 3;
    private void Start()
    {
        system = EventSystem.current;
        isFinalChecked = false;
        isreplay = false;
    }
    void Update()
    {

        displayStarScore();
        if (isreplay)
        {
            Star = 3;


            //SwedishClues.GetComponentInChildren<Text>().text = "";

        }

    }
    private void displayStarScore()
    {
        float quaterOfStar = Star / 0.25f;
        GameObject starScore = GameObject.Find("StarScorePanel");

        for (int i = (int)quaterOfStar; i < 12; i++)
        {
            if (starScore != null)
                starScore.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.black;       //set color for empty star
        }

        for (int i = 0; i < quaterOfStar; i++)
        {
            if (starScore != null)
                starScore.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
    }
    public void FinalCheck()
    {
        if (Star % (int)Star == 0.75f)          //round the score
            Star = Star + 0.25f;
        else
            Star = (int)Star;
        isFinalChecked = true;

        float record = starStats.fillinRecord;

        if (Star > record)
        {
            PlayerStats.instance.playerStars += Star;
            starStats.fillinRecord = Star;
        }
    }
}
    
    




