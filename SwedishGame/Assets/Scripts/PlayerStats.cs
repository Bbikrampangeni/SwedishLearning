using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance = null;

    public float playerStars = 0;

    public float crosswordRecord = 0;
    public float listeningRecord = 0;
    public float fillinRecord = 0;

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

    // Update is called once per frame

    public void AddStars()
    {
        Debug.Log("blöö");
    }
}
