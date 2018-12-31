using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class AssetBundleSample : MonoBehaviour
{
	private DatabaseReference reference;
    private Firebase.Auth.FirebaseAuth auth;
    private float poin;

    public Button buttonBuy;
    public ItemShop itemShop;
    public Text textSold;
    public GameObject lockItem;
    public GameObject overItem;
    public GameObject notEnoughItem;

    void Start ()
	{
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        buttonBuy.onClick.AddListener(clicked);

        if (PlayerPrefs.GetInt("item" + itemShop.id) == 1)
        {
            soldOut();
        }
    }

    void clicked()
    {
        itemShop.StatusBuy = true;
        if (PlayerPrefs.GetInt("item" + itemShop.id) != 1)
            doLoading();
    }

    public void doLoading()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task =>
            {
                DataSnapshot snapshot = task.Result;
                poin = float.Parse(snapshot.Child(auth.CurrentUser.UserId + "/point").Value.ToString());
                if (poin >= itemShop.price)
                {
                    poin -= itemShop.price;
                    reference.Child("users").Child(auth.CurrentUser.UserId).Child("point").SetValueAsync(poin);
                    PlayerPrefs.SetInt("item" + itemShop.id, 1);
                    soldOut();
                }
                else { StartCoroutine(notEnoughSet()); }
            }
        );
    }

    private IEnumerator notEnoughSet()
    {
        notEnoughItem.SetActive(true);
        yield return new WaitForSeconds(2f);
        notEnoughItem.SetActive(false);
    }

    private void soldOut()
    {
        lockItem.SetActive(true);
        overItem.SetActive(true);
        textSold.text = "<color=red>SOLD</color>";
    }
}

