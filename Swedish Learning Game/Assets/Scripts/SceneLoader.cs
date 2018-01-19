using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public Button latvia;
    public Button finland;
    string sceneToLoad;
    
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneSelectionFinland()
    {
        sceneToLoad = "Finland";
    }

    public void SceneSelectionLatvia()
    {
        sceneToLoad = "Latvia";
    }

    public void ButtonAction()
    {
        StartCoroutine(LoadScene(sceneToLoad));
    }

    IEnumerator LoadScene(string scene)
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(scene);
        if (!sceneLoad.isDone)
        {
            yield return null;
        }
    }

}
