using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text coinsText;
    
    void Start()
    {
        coinsText.text = $"Coins : {coins}";

        // 원래 배열은 0부터 시작하지만, 배열을 player prefs로 저장하려면 1부터 시작해야 함(시스템상의 문제로 0 디폴트가 불가능하다)
        // 시스템 저장을 계획하지 않고 있다면 0부터 시작해도 괜찮다.
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        
        // Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 100;
        shopItems[2, 3] = 20;
        shopItems[2, 4] = 30;
        
        // Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>()
            .currentSelectedGameObject;

        if (coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID]++;
            coinsText.text = $"Coins : {coins}";
            buttonRef.GetComponent<ButtonInfo>().quantityText.text =
                $"{shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID]}";
        }
    }
}
