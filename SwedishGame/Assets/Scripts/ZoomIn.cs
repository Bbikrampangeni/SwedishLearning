using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour {
    
    Vector3 position;
    Vector3 CamDefaultPosition;
    public static bool isClicked;
	// Use this for initialization
	void Start () {
        CamDefaultPosition = GameObject.Find("Main Camera").GetComponent<Transform>().position;
	}
	
	void Update () {
        if (isClicked)
        {
            ComicManager.ZoomInPos.z = -2.5f;
            CameraLerp(Camera.main.orthographicSize, 2.1f, Camera.main.transform.position, ComicManager.ZoomInPos);
        }
        else
        {
            CameraLerp(Camera.main.orthographicSize, 8.5f, Camera.main.transform.position, CamDefaultPosition);
        }

    }
    private void OnMouseDown()
    {
        ComicManager.ZoomInPos = this.transform.position;
        isClicked = true;
    }

    private void CameraLerp(float fromCamSize, float toCamSize, Vector3 fromPosition, Vector3 toPosition)
    {
        Camera.main.orthographicSize = Mathf.Lerp(fromCamSize, toCamSize, 0.8f * Time.deltaTime * 60);
        Camera.main.transform.position = Vector3.Lerp(fromPosition, toPosition, 0.05f * Time.deltaTime * 60);
    }
}
