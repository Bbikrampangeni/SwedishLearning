using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButtonActivate : MonoBehaviour {

    public int correctAnswers = drophand.correctAnswers;
    public GameObject sendButton;

    private void Start()
    {
        sendButton.SetActive(false);
    }

    private void Update()
    {
        correctAnswers = drophand.correctAnswers;
        if (correctAnswers == 8)
        {
            sendButton.SetActive(true);
        }
    }


}
