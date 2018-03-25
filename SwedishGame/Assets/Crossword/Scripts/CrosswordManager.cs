using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrosswordManager : MonoBehaviour {
    
    public GameObject SwedishClues;
    public GameObject EngClues;
    public GameObject FinishButton;
    public GameObject TranslateButton;
    public GameObject InsertButton;
    public GameObject Congratulation;
    public GameObject WelcomeScreen;
    public GameObject Grid;
    public GameObject StarObject;
    public GameObject StarPrefab;
    public GameObject FinalResult;

    public static string TheWord = "";
    public static string WordPosition = "";
    public static string Clue = "";             //in English
    public static string SwedishClue = "";
    public static bool IsAcross = true;
    public static bool isReplay;
    public static bool isFinalChecked;
    public static int LengthOfWord = 0;
    public static float Star = 3;


    private GameObject LastSelectedGameObject;
    private EventSystem system;
    private string WorkOnNewWord;               
    private int cursorCount = 0;
    private bool isInserted;                    //control cursor after inserting a letter
    private bool isWordCorrectClick;
    private bool mark;                          //used for translate scoring
    private bool isWelcome;

    PlayerStats starStats = PlayerStats.instance;

    void Start ()
    {
        system = EventSystem.current;
        LastSelectedGameObject = null;
        WorkOnNewWord = TheWord;
        isInserted = false;
        isWordCorrectClick = false;
        isFinalChecked = false;
        mark = false;
        isWelcome = false;
        isReplay = false;
    }
	
	void Update () {
        if (WorkOnNewWord != TheWord)        //changing to other word
        {            
            isWordCorrectClick = false;
            EngClues.SetActive(false);
            mark = true;
            WorkOnNewWord = TheWord;
        }        

        if (system.currentSelectedGameObject != null)            //save the last working box
        {
            if(system.currentSelectedGameObject.tag == "Crossword" && system.currentSelectedGameObject.name != "Replay")
            {
                LastSelectedGameObject = system.currentSelectedGameObject;
                FinishButton.SetActive(true);
                TranslateButton.SetActive(true);
                InsertButton.SetActive(true);
            }            
        }        

        if (LastSelectedGameObject != null)
        {
            SwedishClues.SetActive(true);
            ToUpperCase();
            CursorControl();
            ResetTextColor();
            SwedishClues.GetComponentInChildren<Text>().text = SwedishClue;
        }

        if(!isFinalChecked)
            SetBoxColor();

        displayStarScore();
        if (isWelcome && !isFinalChecked)
        {
            WelcomeScreen.SetActive(false);
            Grid.SetActive(true);
            StarObject.SetActive(true);
            Congratulation.SetActive(false);
        }
        else if(!isWelcome && !isFinalChecked)
        {
            WelcomeScreen.SetActive(true);
            Grid.SetActive(false);
            StarObject.SetActive(false);
        }

        else if(isWelcome && isFinalChecked)
        {
            WelcomeScreen.SetActive(false);
            Grid.SetActive(true);
            StarObject.SetActive(true);
            Congratulation.SetActive(false);
        }

        if (isReplay)
        {
            Star = 3;
            EngClues.SetActive(false);
            SwedishClues.SetActive(false);
            //SwedishClues.GetComponentInChildren<Text>().text = "";
            TheWord = "";
        }
        
        
    }//Update()

    public void ExitButton()
    {
        SceneManager.LoadScene("Latvia");
    }

    public void Replay()
    {
        isReplay = true;       
        
    }
    public void CongratulationEnable()
    {
        Congratulation.SetActive(true);

    }

    public void WelcomeDisable()
    {
        isWelcome = true;
    }

    private void displayStarScore()
    {
        float quaterOfStar = Star / 0.25f;
        GameObject starScore = GameObject.Find("StarScorePanel");

        for(int i = (int)quaterOfStar; i < 12; i++)
        {
            if(starScore != null)
                starScore.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.black;       //set color for empty star
        }        

        for(int i = 0; i < quaterOfStar;i++)
        {
            if(starScore != null)
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
        
        foreach(GameObject game in GameObject.FindGameObjectsWithTag("Crossword"))
        {
            Check check = game.GetComponent<Check>();
            check.isCorrectLetterChecked = false;
            if (check.SaveChar.ToString().ToUpper() == game.GetComponent<InputField>().text)        //update text color      
                game.transform.Find("Text").GetComponent<Text>().color = Color.blue;          
            else          
                game.transform.Find("Text").GetComponent<Text>().color = Color.red;
         
            if(check.SaveChar != ' ')
                game.GetComponent<Image>().color = Color.cyan;
            game.GetComponent<InputField>().enabled = false;
        }

        for(int i = 0; i < (int) Star; i++)
        {
            Instantiate(StarPrefab, FinalResult.transform);
        }

        float record = starStats.crosswordRecord;
        if (Star > record)
        {
            PlayerStats.instance.playerStars += Star - starStats.crosswordRecord;
            starStats.crosswordRecord = Star;
        }
 
    }

    private void ResetTextColor()
    {
        Check check = LastSelectedGameObject.GetComponent<Check>();
        InputField inputField = LastSelectedGameObject.GetComponent<InputField>();

        if(check.isCorrectLetterChecked && check.SaveChar.ToString().ToUpper() != inputField.text && inputField.text.Length != 0 )
            LastSelectedGameObject.transform.Find("Text").GetComponent<Text>().color = Color.red;

        else if(check.isCorrectLetterChecked && check.SaveChar.ToString().ToUpper() == inputField.text && inputField.text.Length != 0)
            LastSelectedGameObject.transform.Find("Text").GetComponent<Text>().color = Color.blue;
    }

    public void EnglishTranslate()
    {
        if(Star >= 1 && !isFinalChecked)
        {
            EngClues.SetActive(true);
            EngClues.GetComponentInChildren<Text>().text = Clue;
            if (mark)
            {
                Star -= 1;
                mark = false;
            }                
        }
    }
    public void InsertLetter()
    {
        if(LastSelectedGameObject != null && Star > 0 && !isFinalChecked)
        {
            LastSelectedGameObject.GetComponent<InputField>().text = LastSelectedGameObject.GetComponent<Check>().SaveChar.ToString();
            LastSelectedGameObject.GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
            LastSelectedGameObject.GetComponent<Check>().isCorrectLetterChecked = true;
            isInserted = true;
            Star -= 0.25f;
        }            
    }

   void ToUpperCase()
    {
        if(LastSelectedGameObject != null)
            LastSelectedGameObject.GetComponent<InputField>().text = LastSelectedGameObject.GetComponent<InputField>().text.ToUpper();        
    }

    private void SetBoxColor()
    {
        GameObject[] words = GameObject.FindGameObjectsWithTag("Crossword");
        GameObject currentGameObject = LastSelectedGameObject;
                
        foreach (GameObject gameobject in words)
        {
            if (gameobject.GetComponent<Check>().SaveChar != ' ' && TheWord != "")
            {
                Image image = gameobject.GetComponent<Image>();
                Check check = gameobject.GetComponent<Check>();              
                    
                if ((check.InAcross == TheWord || check.InDown == TheWord))
                {
                    image.color = new Color32(135, 210, 212, 255);
                }
                else
                    image.color = Color.white;

                if (currentGameObject != null && currentGameObject.tag == "Crossword")          //highlight the current box
                    currentGameObject.GetComponent<Image>().color = Color.cyan;
            }
            else if (gameobject.GetComponent<Check>().SaveChar == ' ')
            {
                gameobject.GetComponent<Image>().color = Color.black;
                gameobject.transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.white;
                gameobject.transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.white;
                gameobject.transform.GetChild(4).gameObject.GetComponent<Image>().color = Color.white;
                gameobject.transform.GetChild(5).gameObject.GetComponent<Image>().color = Color.white;
            }
                
        }
    }

    private void CursorControl()
    {        
        GameObject gameobject;
       
        int length = LengthOfWord;

        if (system.currentSelectedGameObject == null)
            LastSelectedGameObject.GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
        gameobject = LastSelectedGameObject;
        
        if (gameobject.tag == "Crossword")
        {            
            int row = gameobject.GetComponent<Check>().Row;
            int column = gameobject.GetComponent<Check>().Column;
            bool mouseDown = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2);
            if ((Input.anyKeyDown && !mouseDown && !Input.GetKeyDown(KeyCode.Backspace)) || isInserted)
            {
                if (IsAcross)
                {
                    column++;
                    Check check = gameobject.GetComponent<Check>();

                    if (check.ColumnIndex == length - 1)
                    {
                        column--;
                        GenerateCrossword.ObjectArray[row, column - 1].GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
                    }
                }
                else
                {
                    row++;
                    Check check = gameobject.GetComponent<Check>();

                    if (check.RowIndex == length - 1)
                    {
                        row--;
                        GenerateCrossword.ObjectArray[row - 1, column].GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
                    }
                }
                GenerateCrossword.ObjectArray[row, column].GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
                isInserted = false;
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
    public void CheckWordCorrectButton()
    {
        isWordCorrectClick = !isWordCorrectClick;
    }

    //private bool CheckSingleWord(int length)
    //{
    //    int row = 0;
    //    int column = 0;
    //    bool Correct = false;
    //    if (WordPosition != "")
    //    {
    //        row = int.Parse(WordPosition.Substring(0, 2)) - 1;
    //        column = int.Parse(WordPosition.Substring(3, 2)) - 1;
    //    }

    //    for (int j = 0; j < length; j++)
    //    {
    //        if(WordPosition[WordPosition.Length - 1] == 'a')
    //        {
    //            GameObject gameObject = GenerateCrossword.ObjectArray[row, column + j];
    //            if (gameObject.GetComponentInChildren<Text>().text.ToLower() == gameObject.GetComponent<Check>().SaveChar.ToString())
    //            {
    //                Correct = true;
    //            }                    
    //            else
    //            {
    //                Correct = false;                    
    //                break;
    //            }
    //        }
    //        else if(WordPosition[WordPosition.Length - 1] == 'd')
    //        {
    //            GameObject gameObject = GenerateCrossword.ObjectArray[row + j, column];
    //            if (gameObject.GetComponentInChildren<Text>().text.ToLower() == gameObject.GetComponent<Check>().SaveChar.ToString())
    //            {
    //                Correct = true;
    //            }
    //            else
    //            {
    //                Correct = false;
    //                break;
    //            }
    //        }
    //    }

    //    if (Correct)
    //    {
    //        if(WordPosition[WordPosition.Length - 1] == 'a')
    //        {
    //            for (int i = 0; i < length; i++)
    //                GenerateCrossword.ObjectArray[row, column + i].GetComponent<Check>().isCorrect = "true";
    //        }
    //        else if(WordPosition[WordPosition.Length - 1] == 'd')
    //        {
    //            for (int i = 0; i < length; i++)
    //                GenerateCrossword.ObjectArray[row + i, column].GetComponent<Check>().isCorrect = "true";
    //        }
    //    }
    //    else
    //    {
    //        if(WordPosition[WordPosition.Length - 1] == 'a')
    //        {
    //            for (int i = 0; i < length; i++)
    //            {
    //                GameObject gameobject = GenerateCrossword.ObjectArray[row, column + i];
    //                if (gameobject.GetComponent<Check>().InAcross != "" && gameobject.GetComponent<Check>().InDown != "" && gameobject.GetComponent<Check>().isCorrect != "") {/*do nothing*/ }
    //                else
    //                    gameobject.GetComponent<Check>().isCorrect = "false";
    //            }
    //        }
    //        else if(WordPosition[WordPosition.Length - 1] == 'd')
    //        {
    //            for (int i = 0; i < length; i++)
    //            {
    //                GameObject gameobject = GenerateCrossword.ObjectArray[row + i, column];
    //                if (gameobject.GetComponent<Check>().InAcross != "" && gameobject.GetComponent<Check>().InDown != "" && gameobject.GetComponent<Check>().isCorrect != "") {/*do nothing*/ }
    //                else
    //                    gameobject.GetComponent<Check>().isCorrect = "false";
    //            }
    //        }

    //    }

    //    return Correct;

    //}

    //private void InputfiledCursorControl(bool check)
    //{
    //    GameObject TextInput = GameObject.Find("TextInput");

    //    if (cursorCount == TextInput.transform.childCount || check)
    //        cursorCount = 0;        

    //    if(TextInput.transform.childCount != 0)
    //    {
    //        TextInput.transform.GetChild(cursorCount).GetComponent<InputField>().OnPointerClick(new PointerEventData(system));
    //        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetKeyDown(KeyCode.Backspace))
    //        {
    //            cursorCount++;
    //        }
    //        else if(Input.GetMouseButtonDown(0) && system.currentSelectedGameObject != null)
    //        {
    //            if(system.currentSelectedGameObject.transform.IsChildOf(TextInput.transform))
    //            cursorCount = system.currentSelectedGameObject.transform.GetSiblingIndex();
    //        }
    //        else if (Input.GetKeyDown(KeyCode.Backspace))
    //        {
    //            cursorCount--;
    //            if (cursorCount < 0)
    //                cursorCount = TextInput.transform.childCount - 1;
    //        }
    //    }

    //}

    //private void DeletePriviousTextBox()
    //{
    //    GameObject TextInput = GameObject.Find("TextInput");
    //    for (int i = 0; i < TextInput.transform.childCount; i++)
    //        Destroy(TextInput.transform.GetChild(i).gameObject);
    //}

    //private void CreateInputBox(int length)
    //{
    //    GameObject TextInput = GameObject.Find("TextInput");
    //    Vector2 cellSize = TextInput.GetComponent<GridLayoutGroup>().cellSize;

    //    int row = 0;
    //    int column = 0;

    //    char lastLetter = ReturnPositionOfWord(ref row, ref column, WordPosition, length);

    //    if (length == 0)
    //    {
    //        cellSize.y = 0;
    //    }
    //    TextInput.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize.x * length, cellSize.y);       //create box

    //    for (int i = 0; i < length; i++)
    //    {
    //        GameObject singleBox = Instantiate(InputBox, TextInput.transform);

    //        if (lastLetter == 'a')
    //        {                
    //            singleBox.GetComponent<InputField>().text = GenerateCrossword.ObjectArray[row, column + i].GetComponentInChildren<Text>().text;
    //        }
    //        else if (lastLetter == 'd')
    //        {
    //            singleBox.GetComponent<InputField>().text = GenerateCrossword.ObjectArray[row + i, column].GetComponentInChildren<Text>().text;
    //        }
    //        TextInput.transform.GetChild(0).GetComponent<InputField>().OnPointerClick(new PointerEventData(system));            //set cursor

    //    }        
    //}

    //private void DisplayResult(bool checkWord, bool checkCanvasActive)
    //{
    //    if (checkCanvasActive)
    //    {
    //        ResultCanvas.SetActive(true);

    //        GameObject correct = ResultCanvas.transform.GetChild(0).gameObject;
    //        GameObject incorrect = ResultCanvas.transform.GetChild(1).gameObject;

    //        if (checkWord)
    //        {
    //            correct.SetActive(true);
    //            incorrect.SetActive(false);
    //        }
    //        else
    //        {
    //            correct.SetActive(false);
    //            incorrect.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        ResultCanvas.SetActive(false);
    //    }

    //}

    //private void ToUpperCaseInputField()
    //{
    //    GameObject TextInput = GameObject.Find("TextInput");
    //    int length = TextInput.transform.childCount;

    //    for(int i = 0; i < length; i++)
    //    {
    //        GameObject text = TextInput.transform.GetChild(i).gameObject;

    //        text.GetComponent<InputField>().text = text.GetComponent<InputField>().text.ToUpper();
    //    }
    //}

    //private void DisplayCharacterOnGrid()
    //{
    //    int row = 0;
    //    int column = 0;
    //    if(WordPosition != "")
    //    {
    //        row = int.Parse(WordPosition.Substring(0, 2)) - 1;
    //        column = int.Parse(WordPosition.Substring(3, 2)) - 1;
    //    }


    //    for (int i = 0; i < LengthOfWord; i++)
    //    {
    //        GameObject text = GameObject.Find("TextInput").transform.GetChild(i).gameObject;


    //        if (WordPosition[WordPosition.Length - 1] == 'a')
    //        {
    //            GenerateCrossword.ObjectArray[row, column + i].transform.GetChild(0).gameObject.GetComponent<Text>().text = text.GetComponentInChildren<Text>().text.ToUpper();
    //        }
    //        else if (WordPosition[WordPosition.Length - 1] == 'd')
    //        {
    //            GenerateCrossword.ObjectArray[row + i, column].transform.GetChild(0).gameObject.GetComponent<Text>().text = text.GetComponentInChildren<Text>().text.ToUpper();
    //        }
    //    }
    //}
}
