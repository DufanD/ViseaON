using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

public class PlayerInfo : MonoBehaviour {
    public Text textTime;
    public Text textPoint;
    public Text textName;
    
    private Firebase.Auth.FirebaseAuth auth;
    private float timerDive;
        
    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
            {
                DataSnapshot snapshot = task.Result;
                textName.text = snapshot.Child(auth.CurrentUser.UserId + "/displayName").Value.ToString();
            }
        );
    }
	
	// Update is called once per frame
	void Update () {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
            {
                DataSnapshot snapshot = task.Result;
                timerDive = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/time").Value.ToString());
                timerDive = (float) Math.Round(timerDive, 1, MidpointRounding.ToEven);
                textTime.text = timerDive.ToString() + " s";
                textPoint.text = snapshot.Child(auth.CurrentUser.UserId + "/point").Value.ToString() + " P";
            }
        );
    }
}
