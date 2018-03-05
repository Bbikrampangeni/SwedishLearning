using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomposi : MonoBehaviour {
    public Vector3[] positions;
	// Use this for initialization
	void Start () {
        int random = Random.Range(0,positions.Length);
        transform.position = positions[random];
	}
	
	
}
