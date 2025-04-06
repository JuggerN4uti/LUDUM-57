using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject CoinObject, GemObject;
    public float depth, chance, bonusChance, chancePercent;

    void Start()
    {
        depth = bonusChance - (transform.position.y * chancePercent);
        chance = (90f + depth) / (386f + depth);

        if (Random.Range(0f, 1f) < chance)
            Spawn();
    }

    void Spawn()
    {
        chance -= 0.3f;
        if (Random.Range(0f, 1.20f) < chance)
            Instantiate(GemObject, transform.position, transform.rotation);
        else Instantiate(CoinObject, transform.position, transform.rotation);
    }
}
