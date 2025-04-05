using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerForm;
    public float movementSpeed, smoothTime;
    public Vector3 offset;
    Vector3 target, refVel;

    void Update()
    {
        target = UpdateTargetPos();
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime); //smoothly move towards the target
        transform.position = tempPos; //update the position
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 pos = PlayerForm.position + offset;
        return pos;
    }
}
