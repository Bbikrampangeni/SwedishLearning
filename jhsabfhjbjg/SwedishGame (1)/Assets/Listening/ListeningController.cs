using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class ListeningController : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject Star;
    public GameObject Subtitle;

    GameObject Question;
    GameObject[] Answer;
    GameObject QuestionsBank;
    Animator m_animator;

    private Button Play;
    
    private AudioSource audioSource;
    private bool isPaused = false;
    private bool confirm;
    bool[] CorrectAnsers;
    bool ScoreCalculated;
    float lerp = 0.001f;
    int index;
    int count = 0;
    float StarScore;   
    

    void Start () {
        QuestionsBank = GameObject.Find("QuestionsBank");
        audioSource = Camera.main.GetComponent<AudioSource>();

        Play = PlayButton.GetComponent<Button>();
        confirm = true;
        m_animator = GameObject.Find("QuestionAndAnswers").GetComponent<Animator>();
        Question = GameObject.Find("Question");
        Answer = GameObject.FindGameObjectsWithTag("Option");
        CorrectAnsers = new bool[6];
        StarScore = 0;
        ScoreCalculated = false;
        Star.SetActive(false);
    }
	
	void Update () {
        displayStarScore();
        CalculateScore();
        DisplaySubtitle();

        Play.onClick.AddListener(PlayAudio);

        if(audioSource.time == audioSource.clip.length)
        {
            isPaused = false;
        }

        if (confirm && index < 6)
        {
            
            GameObject.Find("Question").GetComponent<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].Question;
            GameObject.Find("Answer1").GetComponentInChildren<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].Answer1;
            GameObject.Find("Answer2").GetComponentInChildren<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].Answer2;
            GameObject.Find("Answer3").GetComponentInChildren<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].Answer3;
            m_animator.SetBool("InOut", true);                                                  //set color and animation
            Color qColor = GameObject.Find("Question").GetComponent<Text>().color;              //  
            qColor.a = Mathf.Lerp(1, 0, Time.deltaTime / lerp);                                 //
            GameObject.Find("Question").GetComponent<Text>().color = qColor;        
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Option"))
            {                
                Color color = go.GetComponentInChildren<Text>().color;
                color.a = Mathf.Lerp(1, 0, Time.deltaTime/lerp);

                go.GetComponentInChildren<Text>().color = color;
                lerp += 0.002f;
            }           
        }
        else
        {
            GameObject.Find("Confirm").GetComponent<Button>().enabled = false;
            Color qColor = GameObject.Find("Question").GetComponent<Text>().color;
            qColor.a = Mathf.Lerp(0, 1, Time.deltaTime / lerp);
            GameObject.Find("Question").GetComponent<Text>().color = qColor;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Option"))
            {
                Color color = go.GetComponentInChildren<Text>().color;
                color.a = Mathf.Lerp(0, 1, Time.deltaTime/lerp);

                go.GetComponentInChildren<Text>().color = color;
                lerp += 0.002f;
            }
            m_animator.SetBool("InOut", false);
            count++;
            if (count == 50)
            {
                count = 0;
                confirm = true;
                GameObject.Find("Confirm").GetComponent<Button>().enabled = true;
            }
            
        }

        //DisplaySpectrum();
            
	}

    void DisplaySpectrum()
    {
        
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.Log("here");
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }

    void DisplaySubtitle()
    {
        int index = (int)audioSource.time / 4;
        Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[index].paragraph;
    }

    public void SetActiveSubtitle()
    {
        if (Subtitle.activeInHierarchy)
            Subtitle.SetActive(false);
        else if (!Subtitle.activeInHierarchy)
            Subtitle.SetActive(true);
    }
    public void RePlay()
    {
        SceneManager.LoadScene("ListeningTask");
    }

    void CalculateScore()
    {
        if(index >= 6 && !ScoreCalculated)
        {
            for(int i = 0; i < CorrectAnsers.Length; i++)
            {
                if(CorrectAnsers[i] == true)
                {
                    StarScore += 0.5f;
                }
                else
                {
                    StarScore -= 0.5f;
                }
            }

            if (StarScore <= 0)
                StarScore = 0;

            Star.SetActive(true);
            GameObject.Find("StarScorePanel2").SetActive(false);
            ScoreCalculated = true;
        }
    }

    private void displayStarScore()
    {
        float quaterOfStar = StarScore / 0.25f;

        for (int i = (int)quaterOfStar; i < 12; i++)
        {
            if (Star != null)
                Star.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.black;       //set color for empty star
        }

        for (int i = 0; i < quaterOfStar; i++)
        {
            if (Star != null)
                Star.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
        }
    }
    void PlayAudio()
    {
        if (!isPaused)
            audioSource.Play();
        else
            audioSource.UnPause();
    }

    public void isConfirmed()
    {
        confirm = !confirm;
        
        int CorrectNumber = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].RightAnswer;
        
        if (CorrectNumber == ButtonToggle.PlayerChoice)
        {
            CorrectAnsers[index] = true;
        }
        else
            CorrectAnsers[index] = false;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Option"))
        {
            go.GetComponentInChildren<Text>().color = Color.cyan;
        }
        index++;
    }
}
