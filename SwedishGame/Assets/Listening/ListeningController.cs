using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class ListeningController : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject PlaySutitleButton;
    public GameObject PauseButton;
    public GameObject StopButton;
    public GameObject Star;
    public GameObject Subtitle;
    public GameObject TranslateButton;
    public GameObject TranslateText;

    public GameObject Question;
    GameObject[] Answer;
    GameObject QuestionsBank;
    Animator m_animator;
    PlayerStats stats = PlayerStats.instance;

    //private Button Play;
    
    private AudioSource audioSource;
    private bool playWithSubtitle = false;
    private bool playWithoutSubtitle = false;
    private bool isPaused = false;
    public bool confirm;
    bool[] CorrectAnsers;
    bool ScoreCalculated;
    bool hasPlayed = false;     //temporary
    float lerp = 0.001f;
    int index;
    int count = 0;
    float StarScore;
    int[] Array1;
    

    void Start () {
        QuestionsBank = GameObject.Find("QuestionsBank");
        audioSource = Camera.main.GetComponent<AudioSource>();

        //Play = PlayButton.GetComponent<Button>();
        confirm = false;
        m_animator = GameObject.Find("QuestionAndAnswers").GetComponent<Animator>();
        //Question = GameObject.Find("Question");
        Answer = GameObject.FindGameObjectsWithTag("Option");
        CorrectAnsers = new bool[6];
        StarScore = 3;
        ScoreCalculated = false;
        //Star.SetActive(false);
        Array1 = new int[] { 0, 5, 12, 20, 26, 37, 56, 65, 72, 77, 83, 90, 100 };
        hasPlayed = false;
        //MultiArray = new Array {};
    }
	
	void Update () {
        displayStarScore();
        CalculateScore();
        DisplaySubtitle();
        

        if(audioSource.time == audioSource.clip.length)
        {
            isPaused = false;
        }

        if (audioSource.time > 5)
        {
            hasPlayed = true;
            confirm = true;
            count = 0;
            GameObject.Find("Confirm").GetComponent<Button>().enabled = true;
            //TranslateButton.SetActive(true);
        }

        if (confirm && index < 6)
        {
            GameObject.Find("Question").GetComponent<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].Question;
            TranslateText.GetComponent<Text>().text = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].TranslateQuestions;
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
            if (hasPlayed)
            {
                if (count >= 50)
                {
                    count = 0;
                    confirm = true;
                    GameObject.Find("Confirm").GetComponent<Button>().enabled = true;
                }
            }
            
            
        }

        DisplayButtons();

        if (playWithoutSubtitle)
            PlaySutitleButton.SetActive(false);
        if (playWithSubtitle)
            PlayButton.SetActive(false);

        //Debug.Log(audioSource.isPlaying);
        //DisplaySpectrum();
            
	}

    public void PlaySubtitle()
    {
        playWithSubtitle = true;
        StarScore = 1.5f;
        Subtitle.SetActive(true);
        if (!isPaused)
        {
            audioSource.Play();
        }

        else
        {
            audioSource.UnPause();
            isPaused = false;
        }
    }

    public void PauseAudio()
    {
        audioSource.Pause();
        isPaused = true;
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
    void DisplayButtons()
    {
        if (audioSource.isPlaying)
        {
            PlayButton.SetActive(false);
            PlaySutitleButton.SetActive(false);
            PauseButton.SetActive(true);
            StopButton.SetActive(true);
        }
        else
        {
            PlayButton.SetActive(true);
            PlaySutitleButton.SetActive(true);
            PauseButton.SetActive(false);
            StopButton.SetActive(false);
        }        

    }

    public void ClosePanel()
    {
        Destroy(GameObject.Find("WelcomePanel"));
    }
    public void Exit()
    {
        SceneManager.LoadScene("Latvia");
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
        if(audioSource.time >0 && audioSource.time< 5)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[0].paragraph;
        }
        else if(audioSource.time > 5 && audioSource.time < 12)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[1].paragraph;
        }
        else if(audioSource.time > 12 && audioSource.time < 20)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[2].paragraph;
        }
        else if (audioSource.time > 20 && audioSource.time < 26)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[3].paragraph;
        }
        else if (audioSource.time > 26 && audioSource.time < 37)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[4].paragraph;
        }
        else if (audioSource.time > 37 && audioSource.time < 56)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[5].paragraph;
        }
        else if (audioSource.time > 56 && audioSource.time < 65)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[6].paragraph;
        }
        else if (audioSource.time > 65 && audioSource.time < 72)//Array1 = new int[] { 0, 5, 12, 20, 26, 37, 56, 65, 72, 77, 83, 90, 100 };
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[7].paragraph;
        }
        else if (audioSource.time > 72 && audioSource.time < 77)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[8].paragraph;
        }
        else if (audioSource.time > 77 && audioSource.time < 83)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[9].paragraph;
        }
        else if (audioSource.time > 83 && audioSource.time < 90)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[10].paragraph;
        }
        else if (audioSource.time > 90 && audioSource.time < 100)
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[11].paragraph;
        }
        else
        {
            Subtitle.GetComponent<Text>().text = GameObject.Find("SubtitleText").GetComponent<SubtitleText>().text[12].paragraph;
        }

        
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

            if (StarScore % (int)StarScore == 0.75f)
            {
                StarScore = StarScore + 0.25f;
            }
            else
            {
                StarScore = (int)StarScore;
            }

            float record = stats.listeningRecord;
            if (StarScore > record)
            {
                stats.playerStars += StarScore - record;
                stats.listeningRecord = StarScore;
            }


        }
    }

    private void displayStarScore()
    {

        if (playWithoutSubtitle && StarScore >= 3)
        {
            StarScore = 3;
        }

        if(playWithSubtitle && StarScore >= 1.5f)
        {
            StarScore = 1.5f;
        }
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
    public void PlayAudio()
    {
        playWithoutSubtitle = true;
        if (!isPaused)
        {
            audioSource.Play();
        }

        else
        {
            audioSource.UnPause();
            isPaused = false;
        }            
    }

    public void isConfirmed()
    {
        TranslateButton.SetActive(true);
        TranslateText.SetActive(false);
        confirm = !confirm;
        
        int CorrectNumber = QuestionsBank.GetComponent<Questions>().quesitonsBank[index].RightAnswer;
        
        if (CorrectNumber == ButtonToggle.PlayerChoice)
        {
            CorrectAnsers[index] = true;
            StarScore += 0.25f;
        }
        else
        {
            CorrectAnsers[index] = false;
            StarScore -= 0.25f;
        }
            
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Option"))
        {
            go.GetComponentInChildren<Text>().color = Color.cyan;
        }
        index++;
    }

    public void TranslateQuestion()
    {
        if (playWithoutSubtitle)
        {
            TranslateText.SetActive(true);
            TranslateButton.SetActive(false);
            StarScore -= 0.25f;
        }
        
    }
}
