using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class emailsystem : MonoBehaviour {

    public GameObject email1;
    public GameObject subject1;

    public void SendEmail()
    {
        string email = email1.GetComponent<Text>().text;
  
        string subject = "Receipe";
     
        string body = subject1.GetComponent<Text>().text;
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
   


}
