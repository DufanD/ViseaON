using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class popupMessage : MonoBehaviour {

    public GameObject window;
    public GameObject windowLogin;

    public void Show(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Hide()
    {
        windowLogin.SetActive(true);
        window.SetActive(false);
        
    }
}
