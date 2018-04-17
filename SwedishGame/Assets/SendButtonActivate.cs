using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButtonActivate : MonoBehaviour {

    public int correctAnswers = drophand.correctAnswers;
    public GameObject sendButton;

    private void Start()
    {
        drophand.correctAnswers = 0;
        sendButton.SetActive(false);
    }

    private void Update()
    {
        correctAnswers = drophand.correctAnswers;
        if (correctAnswers == 7)
        {
            sendButton.SetActive(true);
        }
    }


}
