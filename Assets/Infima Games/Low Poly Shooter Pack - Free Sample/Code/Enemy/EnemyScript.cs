using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int EnemyHealth;
    public bool isHit;
    public AnimationClip EnemyDeath;

    void Update()
    {
        if (isHit)
        {
            EnemyHealth--;

            if (EnemyHealth == 0)
            {
                gameObject.GetComponent<Animation>().clip = EnemyDeath;
                gameObject.GetComponent<Animation>().Play();
                Debug.Log("test");
                // Destroy(gameObject);
            }
            isHit = false;
        }
    }
}
