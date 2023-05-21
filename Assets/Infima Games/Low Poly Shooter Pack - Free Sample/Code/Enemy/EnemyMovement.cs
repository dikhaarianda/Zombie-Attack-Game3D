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
    [SerializeField] private AudioClip audioWalk;
    [SerializeField] private AudioClip audioAttack;
    private AudioSource audioSource;
    private Animator anim;
    private bool isAudioPlay;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 1.2f)
        {
            anim.SetTrigger("Attack");
            agent.isStopped = true;
            audioSource.clip = audioAttack;
        }
        else if(dist > 30)
        {
            anim.SetTrigger("Stop");
            agent.isStopped = true;
            audioSource.clip = null;
        }
        else
        {
            anim.SetTrigger("Walk");
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
            audioSource.clip = audioWalk;
        }

        if (!audioSource.isPlaying) audioSource.Play();
        if (audioSource.clip == null) audioSource.Pause();
    }

    public void enemyAttack()
    {
        target.GetComponent<Character>().getDamage(damage);
    }
}
}