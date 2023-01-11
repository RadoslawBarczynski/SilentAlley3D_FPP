using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField]
    private Transform player;

    private void Start()
    {
        GetReferences();
    }

    private void RotateToTarget()
    {
        //transform.LookAt(player);

        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void MoveToPlayer()
    {
        agent.SetDestination(player.position);
        //RotateToTarget();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }



}
