using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class loadData : MonoBehaviour {

    // Use this for initialization
    public GameObject myText;
    public GameObject desc;
    public string LevelName = "Level";
    

    void Start () {
        LevelName = PlayerPrefs.GetString("LevelName");
        TextAsset loadDesc = (TextAsset)Resources.Load("TextFile/" + LevelName);
        desc.GetComponent<Text>().text = loadDesc.text;
        /*
        string path = "Assets/Resources/TextFile/" + LevelName + ".txt";
        StreamReader reader = new StreamReader(path);
        desc.GetComponent<Text>().text = reader.ReadToEnd();
        reader.Close(); 
        */
        //Material skybox = (Material)AssetDatabase.LoadAssetAtPath("Assets/Menu UI/UMenu Gallery/Content/Art/UI/Material/undersea.mat", typeof(Material));
        Material skybox = Resources.Load("Material/undersea") as Material;
        RenderSettings.skybox = skybox;
    }
	
	// Update is called once per frame
	void Update () {
        myText.GetComponent<Text>().text = LevelName.ToString();
    }
   
}
