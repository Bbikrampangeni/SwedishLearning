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
        SceneManager.LoadScene(nextscene);
    }
}
