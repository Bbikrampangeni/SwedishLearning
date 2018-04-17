using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settings_menu : MonoBehaviour
{
    public AudioMixer audiomixer;
    Resolution[] resolutions;
    public Dropdown resolutiondropdown;
    public GameObject Setting;


    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentresolutionindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
        }
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentresolutionindex;
        resolutiondropdown.RefreshShownValue();
    }
    public void setvolume(float volume)
    {

        audiomixer.SetFloat("volume", volume);

    }

    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void setquality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    public void setfullscreen(bool isfullscreen)
    {

        Screen.fullScreen = isfullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    public void quit()
    {
        //Application.Quit();
        Setting.SetActive(false);
    }
}