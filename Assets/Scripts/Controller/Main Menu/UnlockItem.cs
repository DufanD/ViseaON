using UnityEngine;

public class UnlockItem : MonoBehaviour {
    public ItemShop itemShop;
    public GameObject item;

	// Use this for initialization
	void Start () {
        //Instantiate(Resources.Load("Beach/" + itemShop.nameItem) as GameObject);
        
        if (PlayerPrefs.GetInt("item" + itemShop.id) == 1)
        {
            item.SetActive(true);
        }
    }
}
