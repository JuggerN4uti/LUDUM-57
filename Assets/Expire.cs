using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{
    Vector3 StartingPosition;

    void Start()
    {
        StartingPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, StartingPosition) > 10f)
            Destroy(gameObject);
    }
}
