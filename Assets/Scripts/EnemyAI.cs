using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 10f;
    PlayerHealth player;
    Transform target;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;
    public bool isDead = false;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        target = player.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {       
            if(GetComponent<EnemyHealth>().GetisDead())
            { 
            enabled = false;
            navMeshAgent.enabled = false;
            }
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget < chaseRange)
            {
                isProvoked = true;
                EngageTarget();
            }

    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget>navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget<navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 distance = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); 
        //slerp makes turn rotation look smooth

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
