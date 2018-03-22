using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour {

    public void ClickButtonAsync()
    {
        string scene = EventSystem.current.currentSelectedGameObject.name;
        StartCoroutine(LoadSceneAsync(scene));
    }

    public void ClickButton()
    {
        string scene = EventSystem.current.currentSelectedGameObject.name;
        LoadScene(scene);
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
        while (!loadScene.isDone)
            yield return null;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }





}
