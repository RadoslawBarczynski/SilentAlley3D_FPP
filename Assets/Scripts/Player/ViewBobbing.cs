using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    public float EffectIntensity;
    public float EffectIntensityX;
    public float EffectSpeed;

    private PositionFollower _followerInstance;
    private Vector3 _originalOffset;
    private float SinTime;

    void Start()
    {
        _followerInstance = GetComponent<PositionFollower>();
        _originalOffset = _followerInstance.Offset;
    }

    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));

        if (inputVector.magnitude > 0f)
        {
            SinTime += Time.deltaTime * EffectSpeed;
        }
        else
        {
            SinTime = 0f;
        }

        float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
        Vector3 sinAmountX = _followerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX;

        _followerInstance.Offset = new Vector3
        {
            x = _originalOffset.x,
            y = _originalOffset.y + sinAmountY,
            z = _originalOffset.z
        };

        _followerInstance.Offset += sinAmountX;
    }
}
