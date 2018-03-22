using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour {

     PlayerStats starStats = PlayerStats.instance;
	// Use this for initialization
	public void next(int nextscene)
    {
        starmanger.Star = 3;
        float record = starStats.fillinRecord;

        if (starmanger.Star > record)
        {
            starStats.playerStars += 3;
            SceneManager.LoadScene("Latvia");
            starStats.fillinRecord = 3;
        }
        else
        {
            SceneManager.LoadScene("Latvia");
        }
        

        
    }
}
