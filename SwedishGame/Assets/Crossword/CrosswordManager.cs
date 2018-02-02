﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosswordManager : MonoBehaviour {

    public GameObject AcrossHints;
    public GameObject DownHints;
    public GameObject DisplayHint;
    public GameObject InputBox;
    public GameObject ResultCanvas;

    public static string TheWord = "";
    public static string WordPosition = "";

    public static string Hint = "";
    public static bool isPressed = true;
    public static int LengthOfWord = 0;
    private string WorkOnNewWord;
    private bool isWordCorrectClick = false;

	void Start () {
        CreateInputBox(LengthOfWord);
        WorkOnNewWord = TheWord;
	}
	
	void Update () {
        if(WorkOnNewWord != TheWord)        //detect change to other word
        {
            DeletePriviousTextBox();
            CreateInputBox(LengthOfWord);
            isWordCorrectClick = false;
        }
        WorkOnNewWord = TheWord;

        if (isPressed)      //control Hints buttons
        {
            AcrossHints.SetActive(true);
            DownHints.SetActive(false);
        }
        else
        {
            AcrossHints.SetActive(false);
            DownHints.SetActive(true);
        }

        DisplayHint.GetComponent<Text>().text = Hint;
        
        UpdateCellColor();
        DisplayCharacterOnGrid();
        ToUpperCaseInputField();

        if (LengthOfWord != 0)
        {
            bool isCorrect = CheckSingleWord(LengthOfWord);           
            DisplayResult(isCorrect, isWordCorrectClick);                     
        }        
            
    }//Update()

    private void DisplayResult(bool checkWord, bool checkCanvasActive)
    {
        if (checkCanvasActive)
        {
            ResultCanvas.SetActive(true);

            GameObject correct = ResultCanvas.transform.GetChild(0).gameObject;
            GameObject incorrect = ResultCanvas.transform.GetChild(1).gameObject;

            if (checkWord)
            {
                correct.SetActive(true);
                incorrect.SetActive(false);
            }
            else
            {
                correct.SetActive(false);
                incorrect.SetActive(true);
            }
        }
        else
        {
            ResultCanvas.SetActive(false);
        }
        
    }

    private bool CheckSingleWord(int length)
    {
        int row = 0;
        int column = 0;
        bool Correct = false;
        if (WordPosition != "")
        {
            row = int.Parse(WordPosition.Substring(0, 2)) - 1;
            column = int.Parse(WordPosition.Substring(3, 2)) - 1;
        }

        for (int j = 0; j < length; j++)
        {
            if(WordPosition[WordPosition.Length - 1] == 'a')
            {
                GameObject gameObject = GenerateCrossword.ObjectArray[row, column + j];
                if (gameObject.GetComponentInChildren<Text>().text.ToLower() == gameObject.GetComponent<Check>().SaveChar.ToString())
                {
                    Correct = true;
                }                    
                else
                {
                    Correct = false;                    
                    break;
                }
            }
            else if(WordPosition[WordPosition.Length - 1] == 'd')
            {
                GameObject gameObject = GenerateCrossword.ObjectArray[row + j, column];
                if (gameObject.GetComponentInChildren<Text>().text.ToLower() == gameObject.GetComponent<Check>().SaveChar.ToString())
                {
                    Correct = true;
                }
                else
                {
                    Correct = false;
                    break;
                }
            }
        }

        if (Correct)
        {
            if(WordPosition[WordPosition.Length - 1] == 'a')
            {
                for (int i = 0; i < length; i++)
                    GenerateCrossword.ObjectArray[row, column + i].GetComponent<Check>().isCorrect = "true";
            }
            else if(WordPosition[WordPosition.Length - 1] == 'd')
            {
                for (int i = 0; i < length; i++)
                    GenerateCrossword.ObjectArray[row + i, column].GetComponent<Check>().isCorrect = "true";
            }
        }
        else
        {
            if(WordPosition[WordPosition.Length - 1] == 'a')
            {
                for (int i = 0; i < length; i++)
                {
                    GameObject gameobject = GenerateCrossword.ObjectArray[row, column + i];
                    if (gameobject.GetComponent<Check>().InAcross != "" && gameobject.GetComponent<Check>().InDown != "" && gameobject.GetComponent<Check>().isCorrect != "") {/*do nothing*/ }
                    else
                        gameobject.GetComponent<Check>().isCorrect = "false";
                }
            }
            else if(WordPosition[WordPosition.Length - 1] == 'd')
            {
                for (int i = 0; i < length; i++)
                {
                    GameObject gameobject = GenerateCrossword.ObjectArray[row + i, column];
                    if (gameobject.GetComponent<Check>().InAcross != "" && gameobject.GetComponent<Check>().InDown != "" && gameobject.GetComponent<Check>().isCorrect != "") {/*do nothing*/ }
                    else
                        gameobject.GetComponent<Check>().isCorrect = "false";
                }
            }
            
        }

        return Correct;

    }
    private void ToUpperCaseInputField()
    {
        GameObject TextInput = GameObject.Find("TextInput");
        int length = TextInput.transform.childCount;

        for(int i = 0; i < length; i++)
        {
            GameObject text = TextInput.transform.GetChild(i).gameObject;

            text.GetComponent<InputField>().text = text.GetComponent<InputField>().text.ToUpper();
        }
    }

    private void DisplayCharacterOnGrid()
    {
        int row = 0;
        int column = 0;
        if(WordPosition != "")
        {
            row = int.Parse(WordPosition.Substring(0, 2)) - 1;
            column = int.Parse(WordPosition.Substring(3, 2)) - 1;
        }


        for (int i = 0; i < LengthOfWord; i++)
        {
            GameObject text = GameObject.Find("TextInput").transform.GetChild(i).gameObject;


            if (WordPosition[WordPosition.Length - 1] == 'a')
            {
                GenerateCrossword.ObjectArray[row, column + i].transform.GetChild(0).gameObject.GetComponent<Text>().text = text.GetComponentInChildren<Text>().text.ToUpper();
            }
            else if (WordPosition[WordPosition.Length - 1] == 'd')
            {
                GenerateCrossword.ObjectArray[row + i, column].transform.GetChild(0).gameObject.GetComponent<Text>().text = text.GetComponentInChildren<Text>().text.ToUpper();
            }
        }
    }

    private void UpdateCellColor()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Crossword");
        bool isWordCorrect = false;

        if (LengthOfWord != 0)
            isWordCorrect = CheckSingleWord(LengthOfWord);
        foreach (GameObject gameobject in go)
        {
            if (gameobject.GetComponent<Check>().SaveChar != ' ' && TheWord != "")
            {
                Image image = gameobject.GetComponent<Image>();
                Check check = gameobject.GetComponent<Check>();

                if (check.InAcross == TheWord || check.InDown == TheWord)
                {
                    bool isCorrect = CheckSingleWord(LengthOfWord);

                    if (!isWordCorrectClick)
                        image.color = Color.yellow;
                    else
                    {
                        if (isCorrect)                        
                            image.color = Color.green;                        
                        else
                            image.color = Color.grey;
                    }
                }
                    
                else if (check.isCorrect == "true")
                    image.color = Color.green;
                else if (check.isCorrect == "false")
                    image.color = Color.grey;
                else
                    image.color = Color.white;
            }
            else if (gameobject.GetComponent<Check>().SaveChar == ' ')
                gameobject.GetComponent<Image>().color = Color.black;
        }
    }
    private void DeletePriviousTextBox()
    {
        GameObject TextInput = GameObject.Find("TextInput");
        for (int i = 0; i < TextInput.transform.childCount; i++)
            Destroy(TextInput.transform.GetChild(i).gameObject);
    }

    private void CreateInputBox(int length)
    {
        GameObject TextInput = GameObject.Find("TextInput");
        Vector2 cellSize = TextInput.GetComponent<GridLayoutGroup>().cellSize;

        int row = 0;
        int column = 0;

        char lastLetter = ReturnPositionOfWord(ref row, ref column, WordPosition, length);

        if (length == 0)
        {
            cellSize.y = 0;
        }
        TextInput.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize.x * length, cellSize.y);       //create box
        
        for (int i = 0; i < length; i++)
        {
            GameObject singleBox = Instantiate(InputBox, TextInput.transform);

            if (lastLetter == 'a')
            {                
                singleBox.GetComponent<InputField>().text = GenerateCrossword.ObjectArray[row, column + i].GetComponentInChildren<Text>().text;
            }
            else if (lastLetter == 'd')
            {
                singleBox.GetComponent<InputField>().text = GenerateCrossword.ObjectArray[row + i, column].GetComponentInChildren<Text>().text;
            }
        }        
    }

    private char ReturnPositionOfWord(ref int row, ref int column, string position, int WordLength)
    {
        row = 0;
        column = 0;
        char lastLetter = ' ';
        if (WordPosition != "")
        {
            row = int.Parse(WordPosition.Substring(0, 2)) - 1;
            column = int.Parse(WordPosition.Substring(3, 2)) - 1;
        }

        if(WordLength != 0)
        {
            if (position[position.Length - 1] == 'a')
                lastLetter = 'a' ;
            else
                lastLetter = 'd';
        }

        return lastLetter;
    }
    public void CheckButtonPress()
    {
        isPressed = !isPressed;
    }

    public void CheckWordCorrectButton()
    {
        isWordCorrectClick = !isWordCorrectClick;
    }
}