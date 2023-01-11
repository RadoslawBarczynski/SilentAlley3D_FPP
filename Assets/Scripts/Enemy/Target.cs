using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public NavMeshAgent agent;
    public float health = 50f;
    public GameObject head;
    public RagdollController ragdollController;
    public EnemyAI enemyAi;
    public HeadshotBloodActivate headshotBloodActivate;


    public void TakeDamage(float amount)
    {
        health -= amount;
        //Hitmark.enabled = true;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void TakeHeadshot(float amount)
    {
        health -= amount * 1.5f;
        //Hitmark.enabled = true;
        if (health <= 0f)
        {
            DieByHeadShot();
        }
    }

    void Die()
    {
        ragdollController.ActiveRagdoll();
        enemyAi.enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 10f);
    }

    void DieByHeadShot()
    {
        Destroy(head);
        headshotBloodActivate.ActivateBlood();
        ragdollController.ActiveRagdoll();
        enemyAi.enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 10f);
    }


}
