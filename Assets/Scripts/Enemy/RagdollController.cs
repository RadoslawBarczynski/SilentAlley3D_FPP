using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody enemyRb;
    public CapsuleCollider capsuleCollider;

    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        SetCollidersEnabled(true);
        SetRigidbodiesKinematic(true);
        //ActiveRagdoll();
    }

    private void SetCollidersEnabled(bool enabled)
    {
        foreach(Collider col in colliders)
        {
            col.enabled = enabled;
        }
    }

    private void SetRigidbodiesKinematic(bool kinematic)
    {
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = kinematic;
        }
    }

    public void ActiveRagdoll()
    {
        capsuleCollider.enabled = false;
        //enemyRb.isKinematic = true;
        anim.enabled = false;

        SetCollidersEnabled(true);
        SetRigidbodiesKinematic(false);
    }
}
