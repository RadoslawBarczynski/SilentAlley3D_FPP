using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    public Transform TargetTransform;
    public Vector3 Offset;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        //transform.position = TargetTransform.position + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, TargetTransform.position + Offset, ref velocity, smoothTime);
    }
}
