using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicController : MonoBehaviour {

    public Animator PictureAnimator;
    public GameObject Arrow;
    public GameObject CurrentImage;
    public GameObject[] Pictures;
    int Index;
    
    //public Image[] Images;
    //public GameObject NextImage;
    bool isClick;
    int count = 0;
	// Use this for initialization
	void Start () {
        isClick = false;
        Index = 0;
	}
	
	// Update is called once per frame
	void Update () {

        PictureAnimator = Pictures[Index].GetComponent<Animator>();

        if(isClick && Index == Pictures.Length - 1)
        {
            SceneManager.LoadScene("BankTalk");
        }

        if (isClick)
        {            
            PictureAnimator.SetBool("MovingOut", true);
            if(Pictures[Index].GetComponent<RectTransform>().eulerAngles.z >= 40)
            {
                Pictures[Index].SetActive(false);
                Index++;
                Pictures[Index].SetActive(true);
                isClick = false;
            }            
        }

        if(Pictures[Index].GetComponent<RectTransform>().eulerAngles.z <= 10 && PictureAnimator.GetCurrentAnimatorStateInfo(0).IsName("PictureMovingIn"))
        {
            Arrow.SetActive(true);
        }
        else
        {
            Arrow.SetActive(false);
        }
        
	}

    public void ButtonClick()
    {
        isClick = true;        
    }
}
