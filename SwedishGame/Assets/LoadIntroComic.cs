using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntroComic : MonoBehaviour {

    

    public void LoadIntroScene()
    {
        if (PlayerStats.instance.selectedGender == "male")
        {
            SceneManager.LoadScene("IntroMale");
        }
        if (PlayerStats.instance.selectedGender == "female")
        {
            SceneManager.LoadScene("IntroFemale");
        }
    }
}
