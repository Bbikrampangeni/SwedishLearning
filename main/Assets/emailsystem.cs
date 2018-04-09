using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Net.Mail;


public class emailsystem : MonoBehaviour {

    public GameObject email1;
    public GameObject subject1;
    
    


    public void SendEmail()
    {
        Attachment attachment = null;
        attachment = new Attachment("./Assets/Testtxt.txt");
       
        string email = email1.GetComponent<Text>().text;
        string end = "sent from the Swedish learning game";
        string subject = "Receipe";
     
        string body = subject1.GetComponent<Text>().text;
    
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body + "\n" 
            +end + attachment );
    }
    

    }

