using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class loadData : MonoBehaviour {

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        FirebaseDatabase.DefaultInstance.GetReference("users")
            .OrderByChild("ZUBHtYwYmOYKCsJ78bxdWGB5OHv1").LimitToLast(1).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("Load data Gagal");
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("Load data berhasil");
                    DataSnapshot snapshot = task.Result;
                }
            });    
    }
}
