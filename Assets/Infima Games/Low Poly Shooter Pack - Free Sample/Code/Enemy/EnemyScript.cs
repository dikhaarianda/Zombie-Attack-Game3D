using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int EnemyHealth;
    [SerializeField] private AudioClip audioDead;
    private EnemyMovement enemyMovement;
    private AudioSource audioSource;
    private Animator anim;
    public bool isHit;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
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
                audioSource.clip = audioDead;
                audioSource.Play();
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