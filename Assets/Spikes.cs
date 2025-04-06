using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public Collider2D abyssCollider;
    bool spikey;
    public float firstDelay, retractTime, expandTime;

    void Start()
    {
        Invoke("Change", firstDelay);
    }

    void Change()
    {
        if (spikey)
            Retract();
        else Expand();
    }

    void Retract()
    {
        Sprite.enabled = false;
        abyssCollider.enabled = false;
        spikey = false;
        Invoke("Change", retractTime);
    }

    void Expand()
    {
        Sprite.enabled = true;
        abyssCollider.enabled = true;
        spikey = true;
        Invoke("Change", expandTime);
    }
}
