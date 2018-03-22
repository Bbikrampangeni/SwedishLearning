using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour {

    int zoom = 15;
    int normal = 60;
    float smooth = 5;

    private bool iszoomed = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            iszoomed = !iszoomed;
        }

        if (iszoomed == true)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);

        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
