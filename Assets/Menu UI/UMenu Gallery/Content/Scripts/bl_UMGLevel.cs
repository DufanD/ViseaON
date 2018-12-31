using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class bl_UMGLevel : MonoBehaviour
{
    public string LevelName = "Level";
    public Text NameText = null;
    public Image PreviewImage = null;
    public Image LockImage;
    public bool Unlock = true;
    public GameObject myText;
    public GameObject lockOver;

    private Firebase.Auth.FirebaseAuth auth;
    
    /// Level(XP,Kills,Point,etc...) needed for unlock this level
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
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        cekStatusUnlockDestination();

        if (PlayerPrefs.GetInt("unlock" + LevelName.Replace(" ", "")) == 1)
        {
            Unlock = true;
            LockImage.gameObject.SetActive(false);
            lockOver.SetActive(false);
        }
    }

    private void cekStatusUnlockDestination()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
            {
                DataSnapshot snapshot = task.Result;
                float cekTime = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/time").Value.ToString());
                if (cekTime >= 500)
                {
                    PlayerPrefs.SetInt("unlockBangsring", 1);
                }
                if (cekTime >= 250)
                {
                    PlayerPrefs.SetInt("unlockGiliLabak", 1);
                }

            }
        );
    }
    
    public void Select()
    {
        if (!Unlock)
        {
            myText.SetActive(true);
            myText.GetComponent<Text>().text = "LOCKED";
        } else
        {
            MENU_ACTION_GotoPage("info");
        }

        isSelect = !isSelect;

        if (isSelect)
        {
            PreviewImage.color = SelectColor;
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
        
    public void GetInfo(string Lname, Sprite preview, int LNeeded)
    {
        LevelName = Lname;
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
        } else
        {
            Unlock = true;

            if (LockImage != null)
            {
                LockImage.gameObject.SetActive(false);
            }
        }
    }
}
