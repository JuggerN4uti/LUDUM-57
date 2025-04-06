using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Gameplay")]
    public Perma PermaScript;

    [Header("Gameplay")]
    public GameObject PlayerObject;
    public Transform PlayerForm, DeathForm;
    public bool alive, ready;
    public int meters, gold;
    public float maxDepth;

    [Header("Screens")]
    public GameObject[] Screens;
    public TMPro.TextMeshProUGUI DepthText, GoldText;

    void Start()
    {
        maxDepth = transform.position.y;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
            Move('S');
        else if (Input.GetKey(KeyCode.W))
            Move('W');
        else if (Input.GetKey(KeyCode.A))
            Move('A');
        else if (Input.GetKey(KeyCode.D))
            Move('D');

        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    void Move(char direction)
    {
        if (ready && alive)
        {
            switch (direction)
            {
                case 'S':
                    PlayerForm.position = PlayerForm.position + new Vector3(0f, -0.8f, 0f);
                    break;
                case 'W':
                    PlayerForm.position = PlayerForm.position + new Vector3(0f, 0.8f, 0f);
                    break;
                case 'A':
                    PlayerForm.position = PlayerForm.position + new Vector3(-0.8f, 0f, 0f);
                    break;
                case 'D':
                    PlayerForm.position = PlayerForm.position + new Vector3(0.8f, 0f, 0f);
                    break;
            }
            if (transform.position.y < maxDepth)
                maxDepth = transform.position.y;
            DeathForm.position = new Vector3(PlayerForm.position.x, DeathForm.position.y, DeathForm.position.z);
            DisplayDepth();
            ready = false;
            Invoke("Recover", 0.195f);
        }

    }

    void Recover()
    {
        ready = true;
    }

    void DisplayDepth()
    {
        float temp = 4f - maxDepth;
        temp /= 0.8f;
        meters = Mathf.RoundToInt(temp);

        if (meters >= 1000)
        {
            if (meters % 1000 < 100)
            {
                if (meters % 1000 < 10)
                {
                    if (meters % 1000 == 0)
                        DepthText.text = (meters / 1000).ToString("") + ",000m";
                    else DepthText.text = (meters / 1000).ToString("") + ",00" + (meters % 1000).ToString("") + "m";
                }
                else DepthText.text = (meters / 1000).ToString("") + ",0" + (meters % 1000).ToString("") + "m";
            }
            else DepthText.text = (meters / 1000).ToString("") + "," + (meters % 1000).ToString("") + "m";
        }
        else DepthText.text = meters.ToString("") + "m";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Abyss")
        {
            Death();
            //Destroy(gameObject);
        }
        if (other.transform.tag == "Coin")
        {
            GainGold(1);
            Destroy(other.gameObject);
        }
    }

    void Death()
    {
        alive = false;
        PlayerObject.SetActive(false);
        PermaScript.RunSummary();
        Screens[0].SetActive(false);
        Screens[1].SetActive(true);
    }

    void GainGold(int amount)
    {
        gold += amount;
        GoldText.text = "+" + gold.ToString("");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
