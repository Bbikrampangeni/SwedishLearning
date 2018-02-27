using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public Button loadScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        StartCoroutine("AsyncSceneLoader");
    }

    IEnumerator AsyncSceneLoader()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync("Latvia");
        if (!loadScene.isDone)
        {
            yield return null;
        }
    }

}
