using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateCrossword : MonoBehaviour {

    public static GenerateCrossword _GenerateCrossword;

    public GameObject word;
    public static GameObject[,] ObjectArray;
    public int GridSize;

    private int Column;
    private int Row;

    private int InRow;
    private int InColumn;
        
    private string position = "";
    private string Word = "";    
    private string originalText = "";
    private string EnglishClue = "";
    private string SwedishClue = "";


    private void Start()
    {
        Column = Row = GridSize;
        ObjectArray = new GameObject[Row, Column];

        SetPanleSize(Row, Column);
        GenerateGrid(Row, Column);
        ReadAndLoadText();

        DisableInputField();
    }

    private void Update()
    {
        if (CrosswordManager.isReplay)                      //replay
        {
            foreach(GameObject go in ObjectArray)
            {
                Destroy(go);
            }

            Column = Row = GridSize;
            ObjectArray = new GameObject[Row, Column];

            SetPanleSize(Row, Column);
            GenerateGrid(Row, Column);
            ReadAndLoadText();
            DisableInputField();
            CrosswordManager.isReplay = false;
            CrosswordManager.isFinalChecked = false;
        }
    }
    void DisableInputField()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Crossword"))
        {
            if (go.GetComponent<Check>().SaveChar == ' ')
                go.GetComponent<InputField>().enabled = false;
        }
    }

    void ReadAndLoadText()
    {
        int i = 0;
        string[] CrosswordFiles = { "Assets/Resources/FirstCrossword.txt", "Assets/Resources/SecondCrossword.txt" };
        System.Random random = new System.Random();

        int randomNumber = random.Next(0, CrosswordFiles.Length);
        StreamReader reader = new StreamReader(CrosswordFiles[randomNumber], System.Text.Encoding.GetEncoding("iso-8859-1"), true);

        while ((originalText = reader.ReadLine()) != null)
        {
            int length = originalText.IndexOf("sweClue") -  originalText.IndexOf("engTrans");
            position = originalText.Substring(0, 7);
            EnglishClue = originalText.Substring(originalText.IndexOf("engTrans"), length).Replace("engTrans ", "");
            Word = originalText.Substring(8, originalText.IndexOf("engTrans")).Replace(" engTrans", "");
            SwedishClue = originalText.Substring(originalText.IndexOf("sweClue")).Replace("sweClue ", "");

            InRow = int.Parse(position.Substring(0, 2)) - 1;
            InColumn = int.Parse(position.Substring(3, 2)) - 1;

            if (position[position.Length - 1] == 'a')
            {
                for (int j = 0; j < Word.Length; j++)
                {
                    Check check = ObjectArray[InRow, InColumn + j].GetComponent<Check>();
                    check.AcrossStart = position;
                    check.InAcross = Word;
                    check.AcrossClue = EnglishClue;
                    check.SweAcrossClue = SwedishClue;
                    check.ColumnIndex = j;

                    if (check.SaveChar == ' ')
                    {
                        check.SaveChar = Word[j];
                        ObjectArray[InRow, InColumn + j].GetComponent<Image>().enabled = true;
                    }
                }
            }
            else if (position[position.Length - 1] == 'd')
            {                
                for (int j = 0; j < Word.Length; j++)
                {
                    Check check = ObjectArray[InRow + j, InColumn].GetComponent<Check>();
                    check.DownStart = position;
                    check.InDown = Word;
                    check.DownClue = EnglishClue;
                    check.SweDownClue = SwedishClue;
                    check.RowIndex = j;

                    if (check.SaveChar == ' ')
                    {
                        check.SaveChar = Word[j];
                        ObjectArray[InRow + j, InColumn].GetComponent<Image>().enabled = true;
                    }
                }
            }
            i++;
        }
        reader.Close();
    }

    void GenerateGrid(int row, int column)
    {
        int i = 0;
        while (i < row)
        {
            for (int j = 0; j < column; j++)
            {
                ObjectArray[i, j] = Instantiate(word, transform);
                ObjectArray[i, j].name = i.ToString() + "." + j.ToString();
                ObjectArray[i, j].GetComponent<Check>().Row = i;
                ObjectArray[i, j].GetComponent<Check>().Column = j;                
            }
            i++;
        }
    }

    void SetPanleSize(int row, int column)
    {
        Vector2 cellSize = GetComponent<GridLayoutGroup>().cellSize;

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2((cellSize.x + 0.5f) * row, (cellSize.y + 0.5f) * column);
    }    
}
