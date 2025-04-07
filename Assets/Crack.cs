using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    public bool cracking;
    public float RgbaValues;
    public SpriteRenderer SpriteColor;
    public GameObject AbyssObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && !cracking)
        {
            cracking = true;
            Invoke("Perish", 2.11f);
        }
    }

    void Update()
    {
        if (cracking)
        {
            RgbaValues -= 0.4f * Time.deltaTime;
            SpriteColor.color = new Color(RgbaValues, RgbaValues, RgbaValues, RgbaValues);
        }
    }

    void Perish()
    {
        Instantiate(AbyssObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
