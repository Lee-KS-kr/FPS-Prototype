using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public Text priceText;
    public Text quantityText;
    public GameObject shopManager;

    // Update is called once per frame
    void Update()
    {
        priceText.text = $"Price : {shopManager.GetComponent<ShopManager>().shopItems[2, itemID]}";
        quantityText.text = $"{shopManager.GetComponent<ShopManager>().shopItems[3, itemID]}";
    }
}
