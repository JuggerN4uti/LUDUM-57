using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform EnemyForm;
    public Vector3[] MovePoint;
    public bool[] turnLeft;
    public bool moving;
    public float movementSpeed, pauseTime;
    public int destination;

    void Start()
    {
        for (int i = 0; i < MovePoint.Length; i++)
        {
            MovePoint[i] += transform.position;
        }
        Invoke("Move", pauseTime);
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, MovePoint[destination], movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, MovePoint[destination]) <= 0.005f)
            {
                moving = false;
                Invoke("Move", pauseTime);
            }
        }
    }

    void Move()
    {
        destination++;
        if (destination >= MovePoint.Length)
            destination = 0;
        if (turnLeft[destination])
            EnemyForm.localScale = new Vector3(-0.8f, 0.8f, 1f);
        else EnemyForm.localScale = new Vector3(0.8f, 0.8f, 1f);
        moving = true;
    }
}
