using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseHandlerScript : MonoBehaviour {

    string databaseFetch = "http://Localhost/dbmanager.php";
    string databasePush = "http://Localhost/dbinsert.php?";

    public string playerName;
    public int stars;
    public int id;

    IEnumerator DatabaseConnectionFetch()
    {
        WWW hs_get = new WWW(databaseFetch);
        yield return hs_get;
        if (hs_get.error != null) 
        {
            Debug.Log("Error detected: " + hs_get.error);
        }
        else
        {
            Debug.Log(hs_get.text);
        }

    }

    IEnumerator DatabaseConnectionPush(string player, int stars, int id)
    {
        string post_url = databasePush + "name=" + WWW.EscapeURL(playerName) + "&stars=" + stars + "&id=" + id;
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
        {
            Debug.Log("Error attempting to push data to database: " + hs_post.error);
        }
        else
        {
            Debug.Log("Data succesfully pushed to database");
        }
    }

    public void DatabaseLoader()
    {
        StartCoroutine(DatabaseConnectionFetch());
    }

    public void DatabasePusher()
    {
        StartCoroutine(DatabaseConnectionPush(playerName, stars, id));
    }

}
