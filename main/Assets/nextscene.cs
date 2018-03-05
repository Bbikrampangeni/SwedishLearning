using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextscene : MonoBehaviour {

	// Use this for initialization
	public void next(int nextscene)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(nextscene);
#pragma warning restore CS0618 // Type or member is obsolete

    }
}
