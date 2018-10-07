using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class bl_UMGLevel : MonoBehaviour
{

    public string LevelName = "Level";
    public Text NameText = null;
    public Image PreviewImage = null;
    public Image LockImage;
    public bool Unlock = true;
    public GameObject myText;


    double time = 5.0;
    /// <summary>
    /// Level(XP,Kills,Point,etc...) needed for unlock this level
    /// </summary>
    public int LevelNeeded = 0;
    [Space(5)]
    public Color SelectColor = new Color(0.2f, 0.2f, 0.2f, 0.9f);
    [HideInInspector]
    public bool isSelect = false;
    //Private
    private Color DefaultColor;


    void Start()
    {
        DefaultColor = PreviewImage.color;
        myText.SetActive(false);

    }

   

    /// <summary>
    /// 
    /// </summary>

    public void Select()
    {
        if (!Unlock)
        {

            if (time > 0)
            {
                myText.SetActive(true);
                myText.GetComponent<Text>().text = "TERKUNCI";
            }
 
            //myText.SetActive(False);
        }//if not unlocked, not can select
 

        isSelect = !isSelect;
        if (isSelect)
        {
            PreviewImage.color = SelectColor;
           // bl_UMGManager.instance.DelectAllOther(LevelName);
        }
        else
        {
            PreviewImage.color = DefaultColor;
        }
    }
    public void MENU_ACTION_GotoPage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetString("LevelName",LevelName);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Lname"></param>
    /// <param name="preview"></param>
    /// <param name="LNeeded"></param>
    public void GetInfo(string Lname, Sprite preview, int LNeeded)
    {
        this.LevelName = Lname;
        PreviewImage.sprite = preview;
        LevelNeeded = LNeeded;
        NameText.text = LevelName;
        if (LevelNeeded > bl_UMGManager.PlayerLevel)
        {
            Unlock = false;
            if (LockImage != null)
            {
                LockImage.gameObject.SetActive(true);
            }
        }
        else
        {
            Unlock = true;
            if (LockImage != null)
            {
                LockImage.gameObject.SetActive(false);
            }
        }
    }
}
