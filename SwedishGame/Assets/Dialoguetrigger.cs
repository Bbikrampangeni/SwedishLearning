using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger : MonoBehaviour {

    public dialogue Dialogue;



    public void TriggerDialogue()
    {

        FindObjectOfType<Dialoguemanager>().startdialogue(Dialogue);

    }
}
