using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace InfimaGames.LowPolyShooterPack
{
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int EnemyHealth;
    [SerializeField] private AudioClip audioDead;
    private EnemyMovement enemyMovement;
    private EnemyUI enemyUI;
    private AudioSource audioSource;
    private Animator anim;
    public bool isHit;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyUI = FindAnyObjectByType<EnemyUI>();
    }

    void Update()
    {
        if (isHit)
        {
            EnemyHealth--;
            if (EnemyHealth == 0)
            {
                anim.SetTrigger("Death");
                enemyMovement.enabled = false;
                enemyUI.zombieNum--;
                audioSource.clip = audioDead;
                audioSource.Play();
                GetComponent<NavMeshAgent>().isStopped = true;
                StartCoroutine(DelayTimer());
            }
            isHit = false;
        }
    }

    private IEnumerator DelayTimer () {
		//Wait for random amount of time
		yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
}