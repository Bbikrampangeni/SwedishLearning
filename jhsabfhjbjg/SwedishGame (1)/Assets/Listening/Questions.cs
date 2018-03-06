using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Questions : MonoBehaviour {

    public QuestionsBank[] quesitonsBank;

    [System.Serializable]
    public class QuestionsBank
    {
        [TextArea(3, 10)]
        public string Question;
        [TextArea(2, 10)]
        public string Answer1;
        [TextArea(2, 10)]
        public string Answer2;
        [TextArea(2, 10)]
        public string Answer3;
        public int RightAnswer;
    }
}
