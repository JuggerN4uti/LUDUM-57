using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perma : MonoBehaviour
{
    public Player PlayerScript;
    public int runCoins, totalCoins;

    public void RunSummary()
    {
        runCoins = PlayerScript.gold;
        totalCoins = PlayerPrefs.GetInt("gold") + runCoins;
        PlayerPrefs.SetInt("gold", totalCoins);
    }
}
