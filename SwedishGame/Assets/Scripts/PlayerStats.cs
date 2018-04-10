using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance = null;
    public string selectedGender;

    public float playerStars = 0;
    public float crosswordRecord = 0;
    public float listeningRecord = 0;
    public float fillinRecord = 0;
    public float foodTaskRecord = 0;

    public bool bankVisited = false;

	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
	}    

}
