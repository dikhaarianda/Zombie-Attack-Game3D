using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    private Animator anim;
    public int PlayerHealth;
    private float lastAttack = 0;
    private float cooldownAttack = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 1.2f)
        {
            anim.SetTrigger("Attack");
            agent.isStopped = true;
            enemyAttack();
        }
        else if(dist > 10)
        {
            anim.SetTrigger("Stop");
            agent.isStopped = true;
        }
        else
        {
            anim.SetTrigger("Walk");
            agent.isStopped = false;
            FindTarget();
        }
    }

    private void FindTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    private void enemyAttack()
    {
        if (Time.time - lastAttack >= cooldownAttack)
        {
            lastAttack = Time.time;
            PlayerHealth -= 2;
        }
    }
}
