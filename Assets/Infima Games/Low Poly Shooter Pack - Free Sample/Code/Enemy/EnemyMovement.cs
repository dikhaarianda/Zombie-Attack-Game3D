using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace InfimaGames.LowPolyShooterPack
{
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private int damage;
    private Animator anim;

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
        }
        else if(dist > 20)
        {
            anim.SetTrigger("Stop");
            agent.isStopped = true;
        }
        else
        {
            anim.SetTrigger("Walk");
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
        }
    }

    public void enemyAttack()
    {
        target.GetComponent<Character>().getDamage(damage);
    }
}
}