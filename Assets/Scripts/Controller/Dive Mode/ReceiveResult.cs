using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReceiveResult : MonoBehaviour {

    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);
                
        if (result[0].Contains("back"))
        {
            SceneManager.LoadScene("LoadingExit");
        } else if (result[0].Contains("exit"))
        {
            Application.Quit();
        } else
        {
            GameObject.Find("TextGuide").GetComponent<Text>().text = "Sorry, I don't understand";
        }

    }
}
