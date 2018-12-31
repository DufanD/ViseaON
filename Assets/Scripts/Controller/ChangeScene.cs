using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    private static ChangeScene _instance = null;

    public static ChangeScene Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ChangeScene>();
            }
            return _instance;
        }

    }

    public void changeToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void changeToSceneWithStatus(string scene)
    {
        if (!PlayerPrefs.HasKey("status"))
        {
            PlayerPrefs.SetInt("status", 0);
            SceneManager.LoadScene(scene);
        }
        else
        {
            if (PlayerPrefs.GetInt("status") == 1)
                SceneManager.LoadScene("main");
            else
                SceneManager.LoadScene(scene);
        }
    }
}
