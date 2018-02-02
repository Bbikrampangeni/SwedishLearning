using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateCrossword : MonoBehaviour {

    public GameObject word;
    public static GameObject[,] ObjectArray;

    public int Column;
    public int Row;
    private int InRow;
    private int InColumn;

    private char[,] words;
    private string position = "";
    private string Word = "";
    private string originalText = "";
    private string hint = "";


    private void Start()
    {       
        ObjectArray = new GameObject[Row, Column];
        words = new char[Row, Column];

        SetPanleSize(Row, Column);
        GenerateGrid(Row, Column);
        ReadAndLoadText();    
        
    }
    

    void ReadAndLoadText()
    {
        int i = 0;

        string path = "Assets/Resources/test.txt";
        StreamReader reader = new StreamReader(path);

        while ((originalText = reader.ReadLine()) != null)
        {

            position = originalText.Substring(0, 7);
            for (int j = 0; originalText[j + 8] != ' '; j++)
            {
                Word = originalText.Substring(8, j + 1);
                hint = originalText.Substring(j + 10);
            }

            InRow = int.Parse(position.Substring(0, 2)) - 1;
            InColumn = int.Parse(position.Substring(3, 2)) - 1;

            if (position[position.Length - 1] == 'a')
            {

                for (int j = 0; j < Word.Length; j++)
                {
                    Check check = ObjectArray[InRow, InColumn + j].GetComponent<Check>();
                    check.AcrossStart = position;
                    check.InAcross = Word;
                    check.AcrossHint = hint;

                    if (check.SaveChar == ' ')
                    {
                        check.SaveChar = Word[j];
                        //ObjectArray[InRow, InColumn + j].transform.GetChild(0).GetComponent<Text>().text = Word[j].ToString().ToUpper();
                        ObjectArray[InRow, InColumn + j].GetComponent<Image>().enabled = true;
                    }
                }
            }
            else if (position[position.Length - 1] == 'd')
            {
                for (int j = 0; j < Word.Length; j++)
                {
                    ObjectArray[InRow + j, InColumn].GetComponent<Check>().DownStart = position;
                    ObjectArray[InRow + j, InColumn].GetComponent<Check>().InDown = Word;
                    ObjectArray[InRow + j, InColumn].GetComponent<Check>().DownHint = hint;
                    if (ObjectArray[InRow + j, InColumn].GetComponent<Check>().SaveChar == ' ')
                    {
                        ObjectArray[InRow + j, InColumn].GetComponent<Check>().SaveChar = Word[j];
                        //ObjectArray[InRow + j, InColumn].transform.GetChild(0).GetComponent<Text>().text = Word[j].ToString().ToUpper();
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
            }
            i++;
        }
    }

    void SetPanleSize(int width, int height)
    {
        Vector2 cellSize = GetComponent<GridLayoutGroup>().cellSize;

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(cellSize.x * width, cellSize.y * height);
    }    
}
