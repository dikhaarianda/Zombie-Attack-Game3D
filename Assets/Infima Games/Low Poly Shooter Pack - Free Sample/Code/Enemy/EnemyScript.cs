using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int EnemyHealth;
    public bool isHit;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isHit)
        {
            EnemyHealth--;
            if (EnemyHealth == 0)
            {
                anim.SetTrigger("Death");
                StartCoroutine(DelayTimer());
            }
            isHit = false;
        }
    }

    private IEnumerator DelayTimer () {
		//Wait for random amount of time
		yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
