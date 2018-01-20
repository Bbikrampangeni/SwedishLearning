using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger : MonoBehaviour {

    void OnMouseDown()
    {
        Comic_Manager.gameOjectName = this.gameObject.name;
        Comic_Manager.isTrigger = true;
        Comic_Manager.picturePosition = this.transform.position;
    }
}
