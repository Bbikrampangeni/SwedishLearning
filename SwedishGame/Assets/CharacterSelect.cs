using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{
    public GameObject sceneButton;

    bool maleSelected;
    bool femaleSelected;



    public void SelectCharacter(int gender)
    {
        sceneButton.SetActive(true);

        if (gender == 0)
        {
            PlayerStats.instance.selectedGender = "male";
        }
        if (gender == 1)
        {
            PlayerStats.instance.selectedGender = "female"; 
        }
    }
}
