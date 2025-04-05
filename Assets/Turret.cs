using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject ProjectileObject;
    public Rigidbody2D Body;
    public Transform Barrel;
    public float firstDelay, frequency, force;

    void Start()
    {
        Invoke("Fire", firstDelay);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(ProjectileObject, Barrel.position, transform.rotation);
        Rigidbody2D bullet_body = bullet.GetComponent<Rigidbody2D>();
        bullet_body.AddForce(Barrel.up * force, ForceMode2D.Impulse);

        Invoke("Fire", frequency);
    }
}
