using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;



public class email_system : MonoBehaviour
{

    public GameObject email1;
    public GameObject subject1;
    public GameObject error;




    public void SendEmail()
    {
    

        string email = email1.GetComponent<Text>().text;
        string end = "sent from the Swedish learning game";
        string subject = "Receipe";

        string body = subject1.GetComponent<Text>().text;
        if (email != "")
        {
            Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body + "\n" + end);

        }
        else
        {
            error.gameObject.SetActive(true);
        }

    }


}
