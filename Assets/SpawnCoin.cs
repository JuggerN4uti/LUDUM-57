using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject CoinObject;
    public float depth, chance, bonusChance, chancePercent;

    void Start()
    {
        depth = bonusChance - (transform.position.y * chancePercent);
        chance = (60f + depth) / (290f + depth);

        if (Random.Range(0f, 1f) < chance)
            Spawn();
    }

    void Spawn()
    {
        Instantiate(CoinObject, transform.position, transform.rotation);
    }
}
