using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour {

        public void ClickButton()
        {
                string scene = EventSystem.current.currentSelectedGameObject.name;
                StartCoroutine(LoadScene(scene));
        }

        IEnumerator LoadScene(string scene)
        {
                AsyncOperation loadScene = SceneManager.LoadSceneAsync(scene);
                while (!loadScene.isDone)
                    yield return null;
        }

    public void LoadCrossword()
    {
        SceneManager.LoadScene("Crossword");
    }

    public void LoadListening()
    {
        SceneManager.LoadScene("ListeningTask");
    }
}
