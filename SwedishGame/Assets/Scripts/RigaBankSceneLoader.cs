using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RigaBankSceneLoader : MonoBehaviour {

    public void LoadBankScene()
    {
        if (PlayerStats.instance.selectedGender == "male")
        {
            SceneManager.LoadScene("BankTalkMale");
        }
        if (PlayerStats.instance.selectedGender == "female")
        {
            SceneManager.LoadScene("BankTalkFemale");
        }
    }
}
