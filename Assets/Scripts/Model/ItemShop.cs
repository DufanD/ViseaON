using UnityEngine;

public class ItemShop : MonoBehaviour {
    public int id;
    public string nameItem;
    public float price;
    public string loadUrl;

    public ItemShop() {
        StatusBuy = false;
    }

    public bool StatusBuy { get; set; }
}
