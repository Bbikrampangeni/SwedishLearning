using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleText : MonoBehaviour {

    public SaveText[] text;
	
    [System.Serializable]
    public class SaveText
    {
        [TextArea(3, 10)]
        public string paragraph;        
    }
}
