using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialoguemanager : MonoBehaviour {

    private Queue<string>sentences; // more restrictive and FIFO system.
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private void Start()
    {
        sentences = new Queue<string> ();
    }
    public void startdialogue(dialogue Dialogue)
    {

        animator.SetBool("IsOpen", true);
        nameText.text = Dialogue.heading;

        sentences.Clear();

        foreach (string sentence in Dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(5);
            return;
        }

        string sentence = sentences.Dequeue();
       StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
     void EndDialogue(int scenetochange)
    {
        animator.SetBool("IsOpen", false);
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(scenetochange);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}


