using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour {


    public GameObject loadingscreen;
    public Slider slider;
    public Text progresstext;

    public void LoadLevel(int sceneIndex) {

        StartCoroutine(LoadAsynchronously(sceneIndex));
      
    }
    IEnumerator LoadAsynchronously (int sceneIndex) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // loads the screen asynchronously , can get progress from another scene .

        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); // clamp is the vlaue from 0 to 1 ..
            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
}
