using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RigaCarSceneLoader : MonoBehaviour {

    public void LoadCarSales()
    {
        if (PlayerStats.instance.bankVisited == false)
        {
            if (PlayerStats.instance.selectedGender == "male")
            {
                SceneManager.LoadScene("CarSaleNotHavingMoneyMale");
            }
            if (PlayerStats.instance.selectedGender == "female")
            {
                SceneManager.LoadScene("CarSaleNotHavingMoneyFemale");
            }
        }

        if (PlayerStats.instance.bankVisited == true)
        {
            if (PlayerStats.instance.selectedGender == "male")
            {
                SceneManager.LoadScene("CarSaleMale");
            }
            if (PlayerStats.instance.selectedGender == "female")
            {
                SceneManager.LoadScene("CarSaleFemale");
            }
        }
    }


}
