using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PointController : MonoBehaviour {
    private float poin;
    private DatabaseReference reference;
    private Firebase.Auth.FirebaseAuth auth;

    public PointController() {
    }

    private void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void updatePoint(float sumPoint)
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot snapshot = task.Result;
            poin = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/point").Value.ToString());
            poin += sumPoint;
            reference.Child("users").Child(auth.CurrentUser.UserId).Child("point").SetValueAsync(poin);
        }
        );
    }

    public void updatePointTrash(GameObject trashObject)
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot snapshot = task.Result;
            poin = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/point").Value.ToString());
            poin += 10;
            reference.Child("users").Child(auth.CurrentUser.UserId).Child("point").SetValueAsync(poin);
        }
        );
        trashObject.SetActive(false);
    }

    public void updatePointClickFish(int idFish, bool[] clicked)
    {
        int id = idFish;

        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot snapshot = task.Result;
            poin = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/point").Value.ToString());
            if (clicked[id - 1] == false)
            {
                poin += 10;
                reference.Child("users").Child(auth.CurrentUser.UserId).Child("point").SetValueAsync(poin);
            }
        }
        );

    }
}
