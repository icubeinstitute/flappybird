using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 offset;
    Vector3 pos;

    void Start()
    {
        offset = transform.position - target.position; 
    }

    void LateUpdate()
    {
        pos = target.position + offset;
        pos.y = 0f;
        pos.z = -10f;
        transform.position = pos;
    }
}
