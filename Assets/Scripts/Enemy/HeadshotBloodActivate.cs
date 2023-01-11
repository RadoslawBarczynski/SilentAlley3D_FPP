using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadshotBloodActivate : MonoBehaviour
{
    public ParticleSystem BloodAfterHeadshot;

    public void ActivateBlood()
    {
        BloodAfterHeadshot.Play();
    }
}
