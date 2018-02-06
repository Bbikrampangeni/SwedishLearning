using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFillIn : MonoBehaviour {

    public TextAsset fillIn;
    public string text;
    public string[] splitWords;
    public List<string> words = new List<string>();

	// Use this for initialization
	void Start () {
        ReadFile();
        Prune();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadFile()
    {
        text = fillIn.text;
        splitWords = text.Split('|');
        foreach (var word in splitWords)
        {
            words.Add(word);
        }
    }

    void Prune()
    {
        for (int j = 0; j < words.Capacity; j++)
        {
            if (words[j] == " ")
            {
                words.Remove(words[j]);
            }

            for (int i = 0; i <= words.Capacity; i++)
            {
                if (i % 2 == 0)
                {
                    Debug.Log("Keeping word");
                    Debug.Log(i % 2);
                    Debug.Log(words[i]);
                    
                }
                if (i % 2 == 1)
                {
                    Debug.Log("Remove word");
                    Debug.Log(i % 2);
                    Debug.Log(words[i]);
                    words.Remove(words[i]);
                }
            } 
        }
    }

}
