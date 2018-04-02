using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorControl : MonoBehaviour {

    private EventSystem system;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        system = EventSystem.current;
        InputField firstInputfield = GameObject.Find("InputField").GetComponent<InputField>();
        //firstInputfield.OnPointerClick(new PointerEventData(system));
        //system.currentSelectedGameObject;

        Debug.Log(system.currentSelectedGameObject.name);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {
                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick(new PointerEventData(system));

                system.SetSelectedGameObject(next.gameObject);
            }

            ////Here is the navigating back part:
            //else
            //{
            //    next = Selectable.allSelectables[0];
            //    system.SetSelectedGameObject(next.gameObject);
            //}

        }
    }
}
