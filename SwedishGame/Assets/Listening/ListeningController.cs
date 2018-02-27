using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListeningController : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject PauseButton;

    private Button Play;
    private Button Pause;

    private Slider slider;
    private AudioSource audioSource;
    private double nextTime;
    private bool isPaused = false;
    private GameObject[] options;

   
	void Start () {
        slider = GameObject.Find("PlaySliderBar").GetComponent<Slider>();  
        slider.maxValue = Camera.main.GetComponent<AudioSource>().clip.length;
        audioSource = Camera.main.GetComponent<AudioSource>();

        Play = PlayButton.GetComponent<Button>();
        Pause = PauseButton.GetComponent<Button>();

        options = GameObject.FindGameObjectsWithTag("Option");

        foreach(GameObject go in options)
        {
            go.GetComponent<Toggle>().isOn = false;
        }
       
    }
	
	void Update () {
        slider.value = audioSource.time;

        Play.onClick.AddListener(PlayAudio);
        Pause.onClick.AddListener(PauseAudio);

        if(audioSource.time == audioSource.clip.length)
        {
            isPaused = false;
            PlayButton.SetActive(true);
            PauseButton.SetActive(false);
        }            
	}

    void OptionControl()
    {

    }

    void PauseAudio()
    {
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
        audioSource.Pause();
        isPaused = true;
    }

    void PlayAudio()
    {
        PauseButton.SetActive(true);
        PlayButton.SetActive(false);

        if (!isPaused)
            audioSource.Play();
        else
            audioSource.UnPause();
    }
}
