using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour {

    public string InAcross = "";
    public string InDown = "";
    public string AcrossHint = "";
    public string DownHint = "";
    public char SaveChar = ' ';

    public string AcrossStart = "";
    public string DownStart = "";

    public string isCorrect = "";

    public static Check instance;
    private void Start()
    {
        Button btn =GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (CrosswordManager.isPressed)
        {
            CrosswordManager.Hint = AcrossHint;
            CrosswordManager.LengthOfWord = InAcross.Length;
            CrosswordManager.TheWord = InAcross;
            CrosswordManager.WordPosition = AcrossStart;
        }
        else
        {
            CrosswordManager.Hint = DownHint;
            CrosswordManager.LengthOfWord = InDown.Length;
            CrosswordManager.TheWord = InDown;
            CrosswordManager.WordPosition = DownStart;
        }
    }
}
