using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class infoPanel : MonoBehaviour
{
    public GameObject windowInformation;
    public Text informationNamaIkan;
    public Text informationNamaIlmiah;
    public Text informationLamaHidup;
    public Text informationFaktaUnik;
        
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
    }

    public void FishInformation(string id)
    {
        windowInformation.SetActive(true);
        FirebaseDatabase.DefaultInstance.GetReference("Fauna").GetValueAsync().ContinueWith(task => {
            DataSnapshot snapshot = task.Result;
            informationNamaIkan.text = snapshot.Child(id + "/nama ikan").Value.ToString();
            informationNamaIlmiah.text = snapshot.Child(id + "/nama ilmiah").Value.ToString();
            informationLamaHidup.text = snapshot.Child(id + "/lama hidup").Value.ToString();
            informationFaktaUnik.text = snapshot.Child(id + "/fakta unik").Value.ToString();
        });
    }

    public void exitPanel()
    {
        windowInformation.SetActive(false);
    }
}
