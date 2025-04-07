using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perma : MonoBehaviour
{
    public Player PlayerScript;
    public int runCoins, totalCoins, depth, lastRecord;
    public TMPro.TextMeshProUGUI[] GoldText, DepthText;

    [Header("Shop")]
    public Button[] BuyButton;
    public TMPro.TextMeshProUGUI[] CostText;
    public int[] ArmorCosts, Bought;
    public int armorCost;

    public void RunSummary()
    {
        runCoins = PlayerScript.gold;
        totalCoins = PlayerPrefs.GetInt("gold") + runCoins;
        depth = PlayerScript.meters;
        lastRecord = PlayerPrefs.GetInt("max");
        CheckDepths();
        DisplayGold();
        SetShop();
        CheckShop();
        PlayerPrefs.SetInt("gold", totalCoins);
    }

    void CheckDepths()
    {
        if (depth < lastRecord)
        {
            DepthText[0].text = AdjustText(depth);
            DepthText[1].text = "record:\n" + AdjustText(lastRecord);
        }
        else if (depth > lastRecord)
        {
            DepthText[0].text = "new record!:\n" + AdjustText(depth);
            DepthText[1].text = "last:\n" + AdjustText(lastRecord);
            PlayerPrefs.SetInt("max", depth);
        }
        else
        {
            DepthText[0].text = "same depth\n" + AdjustText(depth);
            DepthText[1].text = "as record\n" + AdjustText(lastRecord);
        }
    }

    void DisplayGold()
    {
        GoldText[0].text = "+" + runCoins.ToString("");
        GoldText[1].text = AdjustText(totalCoins);
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

    string AdjustText(int number)
    {
        if (number >= 1000)
        {
            if (number % 1000 < 100)
            {
                if (number % 1000 < 10)
                {
                    if (number % 1000 == 0)
                        return (number / 1000).ToString("") + ",000";
                    else return (number / 1000).ToString("") + ",00" + (number % 1000).ToString("");
                }
                else return (number / 1000).ToString("") + ",0" + (number % 1000).ToString("");
            }
            else return (number / 1000).ToString("") + "," + (number % 1000).ToString("");
        }
        else return number.ToString("");
    }
}
