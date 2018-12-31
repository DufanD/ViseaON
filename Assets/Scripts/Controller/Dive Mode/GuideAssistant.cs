using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GuideAssistant : MonoBehaviour {
    public Button guideClick;
    public Text textGuide;
    public GameObject infoPanel;

    private AudioSource audioSource;
    private string textAudio;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        guideClick.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.plugin.speech.pluginlibrary.TestPlugin");
        Debug.Log("Call 1 Started");

        // Pass the name of the game object which has the onActivityResult(string recognizedText) attached to it.
        // The speech recognizer intent will return the string result to onActivityResult method of "Main Camera"
        pluginClass.CallStatic("setReturnObject", "Main Camera");
        Debug.Log("Return Object Set");


        // Setting language is optional. If you don't run this line, it will try to figure out language based on device settings
        pluginClass.CallStatic("setLanguage", "en_US");
        Debug.Log("Language Set");


        // The following line sets the maximum results you want for recognition
        pluginClass.CallStatic("setMaxResults", 3);
        Debug.Log("Max Results Set");

        // The following line sets the question which appears on intent over the microphone icon
        pluginClass.CallStatic("changeQuestion", "Hello, How can I help you?");
        Debug.Log("Question Set");

        textAudio = "Hello, How can I help you?";
        StartCoroutine(DownloadTheAudio());

        Debug.Log("Call 2 Started");

        // Calls the function from the jar file
        pluginClass.CallStatic("promptSpeechInput");

        Debug.Log("Call End");
    }

    public void hoverMe()
    {
        infoPanel.SetActive(true);
        int textChoice = Random.Range(1, 4); // creates a number between 1 and 3

        if (textChoice == 1)
        {
            textAudio = "Hello! I am your Guide, Click on me to call me";
            textGuide.text = "Hello! I am your Guide \n Click on me to call me";
        } else if (textChoice == 2)
        {
            textAudio = "I can guide you back to the top, Just click me and try to speak Back";
            textGuide.text = "I can guide you back to the top \n Just click me and try to speak 'Back'";
        } else
        {
            textAudio = "Do you want to exit? Click and speak Exit to me";
            textGuide.text = "Do you want to exit? \n Click and speak 'Exit' to me";
        }
        StartCoroutine(DownloadTheAudio());
    }

    public void unhoverMe()
    {
        infoPanel.SetActive(false);
    }

    IEnumerator DownloadTheAudio()
    {
        Regex rgx       = new Regex("\\s+");
        string result   = rgx.Replace(textAudio, "+");
        string url      = "http://api.voicerss.org/?key=81a4cc6384334cd783a98b498b043aa7&hl=en-us&f=44khz_16bit_stereo&&src="+ result;
        WWW www         = new WWW(url);
        yield return www;

        audioSource.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        audioSource.Play();
    }
}
