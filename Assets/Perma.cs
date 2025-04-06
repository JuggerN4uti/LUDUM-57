using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perma : MonoBehaviour
{
    public Player PlayerScript;
    public int runCoins, totalCoins;
    public TMPro.TextMeshProUGUI[] GoldText;

    [Header("Shop")]
    public Button[] BuyButton;
    public TMPro.TextMeshProUGUI[] CostText;
    public int[] ArmorCosts, Bought;
    public int armorCost;

    public void RunSummary()
    {
        runCoins = PlayerScript.gold;
        totalCoins = PlayerPrefs.GetInt("gold") + runCoins;
        DisplayGold();
        SetShop();
        CheckShop();
        PlayerPrefs.SetInt("gold", totalCoins);
    }

    void DisplayGold()
    {
        GoldText[0].text = "+" + runCoins.ToString("");
        if (totalCoins >= 1000)
        {
            if (totalCoins % 1000 < 100)
            {
                if (totalCoins % 1000 < 10)
                {
                    if (totalCoins % 1000 == 0)
                        GoldText[1].text = (totalCoins / 1000).ToString("") + ",000";
                    else GoldText[1].text = (totalCoins / 1000).ToString("") + ",00" + (totalCoins % 1000).ToString("");
                }
                else GoldText[1].text = (totalCoins / 1000).ToString("") + ",0" + (totalCoins % 1000).ToString("");
            }
            else GoldText[1].text = (totalCoins / 1000).ToString("") + "," + (totalCoins % 1000).ToString("");
        }
        else GoldText[1].text = totalCoins.ToString("");
    }

    void SetShop()
    {
        Bought[0] = PlayerPrefs.GetInt("armor");
        if (Bought[0] < 4)
        {
            armorCost = ArmorCosts[Bought[0]];
            CostText[0].text = armorCost.ToString("");
        }
        else
        {
            BuyButton[0].gameObject.SetActive(false);
            CostText[0].text = "Maxxed";
        }

        // potem else
    }

    void CheckShop()
    {
        if (totalCoins >= armorCost)
            BuyButton[0].interactable = true;
        else BuyButton[0].interactable = false;
    }

    public void BuyUpgrade(int which)
    {
        switch (which)
        {
            case 0:
                totalCoins -= armorCost;
                Bought[0]++;
                PlayerPrefs.SetInt("armor", Bought[0]);
                break;
        }
        PlayerPrefs.SetInt("gold", totalCoins);
        SetShop();
        CheckShop();
    }
}
