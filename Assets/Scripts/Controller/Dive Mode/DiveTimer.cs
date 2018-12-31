using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

public class DiveTimer : MonoBehaviour {
    private float timerDive;
    private float poin;
    private DatabaseReference reference;
    private Firebase.Auth.FirebaseAuth auth;
    private PointController pointController;

    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        pointController = new PointController();
    }
	
	// Update is called once per frame
	void Update () {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot snapshot = task.Result;
            timerDive = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/time").Value.ToString());
            timerDive += Time.deltaTime;
            reference.Child("users").Child(auth.CurrentUser.UserId).Child("time").SetValueAsync(timerDive);
            cekUnlock();
        }
        );
        
    }

    private void cekUnlock()
    {
                
        if (timerDive != 0 && findMod((float) Math.Round(timerDive, 1, MidpointRounding.ToEven), 60) == 0.0)
        {
            pointController.updatePoint(5);
        }

        if ((float) Math.Round(timerDive, 1, MidpointRounding.ToEven) == 500.0)
        {
            PlayerPrefs.SetInt("unlockBangsring", 1);
            pointController.updatePoint(10);

        }
        else if ((float) Math.Round(timerDive, 1, MidpointRounding.ToEven) == 250.0)
        {
            PlayerPrefs.SetInt("unlockGiliLabak", 1);
            pointController.updatePoint(10);
        }
    }

    private float findMod(float a, float b)
    {
        float mod = a;
        while (mod >= b) mod -= b;

        return mod;
    }
       
}
