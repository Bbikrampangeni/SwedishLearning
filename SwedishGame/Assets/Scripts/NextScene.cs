using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public string LoadSceneName = "";
    public GameObject Canvas;

    private bool nextSceneClick = false;
    private bool toNextScene = false;
    private bool newScene = false;
    Color color;

    private void Start()
    {
        newScene = true;
        GetComponent<SpriteRenderer>().enabled = true;
        color = GetComponent<SpriteRenderer>().material.color;
        color.a = 1f;
        GetComponent<SpriteRenderer>().material.color = color;
    }

    void Update () {
        if (newScene)
        {
            ColorLerp(0);
        }

        if (nextSceneClick)
        {
            //toNextScene = true;
            ColorLerp(1);
            Canvas.SetActive(false);
        }
        if (toNextScene)
            SceneManager.LoadScene(LoadSceneName);
            
    }

    public void LoadScene()
    {
        nextSceneClick = true;
        newScene = false;
    }

    private void ColorLerp(float toNumber)
    {
        Color temp = GetComponent<SpriteRenderer>().material.color;
        Color shader = GetComponent<SpriteRenderer>().material.color;

        temp.a = Mathf.Lerp(shader.a, toNumber, 1f * Time.deltaTime);
        if (temp.a <= 0.2f)        
            newScene = false;        

        if (temp.a >= 0.9 && !newScene)
            toNextScene = true;
        
        GetComponent<SpriteRenderer>().material.color = temp;
    }
}
