using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponMovement : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.rotation = Target.rotation;
    }
}
