using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starcount : MonoBehaviour {
 
	// Use this for initialization
	public void counter()
    {
        foodstarcounter.Star -= 1.00f;
    }
    public void stardecrease()
    {
        if (foodstarcounter.Star > 1)
        {
            foodstarcounter.Star += 0.25f;
        }
        if (foodstarcounter.Star<1)
        {
            
        }
    }
}
