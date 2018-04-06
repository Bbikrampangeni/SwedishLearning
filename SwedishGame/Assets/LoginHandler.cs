using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour {

    public InputField account;
    public InputField password;
    string loginUrl = "http://Localhost/login.php??";

    public void LoginButtonPress()
    {
        if (account.text == "" || password.text == "")
        {
            Debug.Log("Must enter both account name and password!");
        }
        else
        {
            StartCoroutine(LoginPush());
        }
    }
    IEnumerator LoginPush()
    {
        string post_url = loginUrl + "accountname=" + WWW.EscapeURL(account.text) + "&password=" + WWW.EscapeURL(password.text);
        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
        {
            Debug.Log("Error while querying the database: " + hs_post.error);
        }
        else
        {
            Debug.Log("Succesfully queried the database");
            WWW hs_get = new WWW(post_url);
            yield return hs_get;
            if (hs_get.error != null)
            {
                Debug.Log("Error while fetching data: " + hs_get.error);
            }
            else
            {
                Debug.Log(hs_get);
                SceneManager.LoadScene(1);
            }
        }
        
    }

}
