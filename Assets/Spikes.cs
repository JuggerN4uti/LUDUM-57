using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public SpriteRenderer SpriteIcon;
    public Sprite normalTile, spikyTile;
    public Collider2D abyssCollider;
    bool spikey;
    public float firstDelay, frequency;

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
        SpriteIcon.sprite = normalTile;
        abyssCollider.enabled = false;
        spikey = false;
        Invoke("Change", frequency);
    }

    void Expand()
    {
        SpriteIcon.sprite = spikyTile;
        abyssCollider.enabled = true;
        spikey = true;
        Invoke("Change", 1.1f);
    }
}
