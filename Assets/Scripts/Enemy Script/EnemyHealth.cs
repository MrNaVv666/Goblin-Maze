using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyScript enemyScript;
    private Animator animator;

    public int health = 20;
    void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        //DISPLAY VAL

        if (health == 0)
        {
            enemyScript.enabled = false;
            animator.SetTrigger(Tags.DEAD_ANIMATION);
            Invoke("DeactivateEnemy", 3f);
        }
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
