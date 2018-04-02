using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic_Manager : MonoBehaviour {

    public static Vector3 picturePosition = Vector3.zero;
    public static bool isTrigger = false;
    public static string gameOjectName = "";
    public GameObject Canvas;

    private Vector3 CamDefaultPosition;

	// Use this for initialization
	void Start () {
        CamDefaultPosition = new Vector3(-0.2f, -1.33f, -0.4f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isTrigger)
        {
            Canvas.SetActive(true);
            picturePosition.z = -2f;
            CameraLerp(Camera.main.orthographicSize, 8f, Camera.main.transform.position, picturePosition);
            TransparentLerp(0);
            
        }
        else
        {
            CameraLerp(Camera.main.orthographicSize, 22f, Camera.main.transform.position, CamDefaultPosition);
            TransparentLerp(1);
        }
	}

    public void NextFrame()
    {

        Vector3 position1 = GameObject.Find("Object1").GetComponent<Transform>().position;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene("ComicSystem2");
    }

    private void CameraLerp(float fromCamSize, float toCamSize, Vector3 fromPosition, Vector3 toPosition)
    {
        Camera.main.orthographicSize = Mathf.Lerp(fromCamSize, toCamSize, 0.03f * Time.deltaTime * 60);
        Camera.main.transform.position = Vector3.Lerp(fromPosition, toPosition, 0.03f * Time.deltaTime * 60);
    }

    public void ZoomOut()
    {
        Canvas.SetActive(false);
        isTrigger = false;
    }

    void TransparentLerp(float to)
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Picture"))
        {
            Color gameObjectColor = gameObject.GetComponent<SpriteRenderer>().material.color;
            Color temp = gameObject.GetComponent<SpriteRenderer>().material.color;
            temp.a = Mathf.Lerp(gameObjectColor.a, to, 1f * Time.deltaTime);
            
            if (gameObject.name != gameOjectName)
            {
                gameObject.GetComponent<SpriteRenderer>().material.color = temp;
            }

            if (to == 0.0)
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            else if(temp.a >= 0.9)
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
