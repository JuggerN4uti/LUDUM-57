using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform PlayerObject;
    public bool caught;
    public float movementSpeed;

    void Update()
    {
        if (!caught)
        {
            if (Vector3.Distance(transform.position, PlayerObject.position) > 4.4)
                transform.position += new Vector3(0f, -1f, 0f) * (movementSpeed + Vector3.Distance(transform.position, PlayerObject.position) * 0.175f) * Time.deltaTime;
            else transform.position += new Vector3(0f, -1f, 0f) * movementSpeed * Time.deltaTime;

            if (transform.position.y < PlayerObject.position.y - 24f)
                caught = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag != "Player")
            Destroy(other.gameObject);
    }
}
