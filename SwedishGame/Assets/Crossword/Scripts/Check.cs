using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[SerializeField]
public class Check : MonoBehaviour {

    public char SaveChar = ' ';
    public string InAcross = "";
    public string InDown = "";
    public string AcrossClue = "";
    public string DownClue = "";
    public string SweAcrossClue = "";
    public string SweDownClue = "";
    public string AcrossStart = "";
    public string DownStart = "";
    public string isCorrect = "";
    public int Row;
    public int Column;
    public int RowIndex;
    public int ColumnIndex;
    public bool isCorrectLetterChecked;

    private EventSystem system;

    public static GameObject LastCrossSelected;

    private void Awake()
    {
        system = EventSystem.current;
        RowIndex = ColumnIndex = -1;
        LastCrossSelected = null;
    }

    private void Start()
    {
        isCorrectLetterChecked = false;
    }

    private void Update()
    {
        if(system.currentSelectedGameObject == this.gameObject)
        {
            TaskOnClick();
        }
        
            
    }
    public void TaskOnClick()
    {
        if (InAcross != "" && InDown != "" && Input.GetMouseButtonDown(0))
        {
            if ((InAcross == CrosswordManager.TheWord || InDown == CrosswordManager.TheWord) && LastCrossSelected == this.gameObject)            
                CrosswordManager.IsAcross = !CrosswordManager.IsAcross;            
        }
        else if (InAcross != "" && InDown == "")
            CrosswordManager.IsAcross = true;
        else if (InDown != "" && InAcross == "")
            CrosswordManager.IsAcross = false;
        LastCrossSelected = this.gameObject;

        if (CrosswordManager.IsAcross)
        {
            CrosswordManager.Clue = AcrossClue;
            CrosswordManager.SwedishClue = SweAcrossClue;
            CrosswordManager.LengthOfWord = InAcross.Length;
            CrosswordManager.TheWord = InAcross;
            CrosswordManager.WordPosition = AcrossStart;
        }
        else
        {
            CrosswordManager.Clue = DownClue;
            CrosswordManager.SwedishClue = SweDownClue;
            CrosswordManager.LengthOfWord = InDown.Length;
            CrosswordManager.TheWord = InDown;
            CrosswordManager.WordPosition = DownStart;
        }
    }
    //public void TaskOnClick()
    //{
    //    if(InAcross != "" && InDown != "")
    //    {
    //        pressCount = !pressCount;

    //        if (pressCount)
    //            CrosswordManager.IsAcross = true;
    //        else
    //            CrosswordManager.IsAcross = false;

    //    }
    //    else if (InAcross != "" && InDown == "")
    //        CrosswordManager.IsAcross = true;
    //    else if (InDown != "" && InAcross == "")
    //        CrosswordManager.IsAcross = false;

    //    if (CrosswordManager.IsAcross)
    //    {
    //        CrosswordManager.Hint = AcrossClue;
    //        CrosswordManager.LengthOfWord = InAcross.Length;
    //        CrosswordManager.TheWord = InAcross;
    //        CrosswordManager.WordPosition = AcrossStart;
    //    }
    //    else
    //    {
    //        CrosswordManager.Hint = DownClue;
    //        CrosswordManager.LengthOfWord = InDown.Length;
    //        CrosswordManager.TheWord = InDown;
    //        CrosswordManager.WordPosition = DownStart;
    //    }
    //}
}
