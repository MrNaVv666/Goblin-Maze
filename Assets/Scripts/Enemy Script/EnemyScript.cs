using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Animator animator;

    private float enemySpeed = 10f;
    private float enemyWatchThreshold = 70f;
    private float enemyAttackThreshold = 6f;

    public GameObject damagePoint;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(GameplayController.instance.isPlayerAlive)
        {
            EnemyAI();
        } else
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.ATTACK_ANIMATION) || animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ANIMATION))
                {
                    animator.SetTrigger(Tags.STOP_TRIGGER);
                }
        }
    }

    void EnemyAI()
    {
        Vector3 distance = player.transform.position - transform.position;
        float magnitude = distance.magnitude;
        distance.Normalize();
        Vector3 velocity = distance * enemySpeed;

        if(magnitude > enemyAttackThreshold && magnitude < enemyWatchThreshold)
        {
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.ATTACK_ANIMATION))
            {
                animator.SetTrigger(Tags.STOP_TRIGGER);
            }
            animator.SetTrigger(Tags.RUN_ANIMATION);
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }else if (magnitude < enemyAttackThreshold)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ANIMATION))
            {
                animator.SetTrigger(Tags.STOP_TRIGGER);
            }
            animator.SetTrigger(Tags.ATTACK_TRIGGER);
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }else
        {
            rb.velocity = new Vector3 (0f, 0f, 0f);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.RUN_ANIMATION) || animator.GetCurrentAnimatorStateInfo(0).IsName(Tags.ATTACK_ANIMATION))
            {
                animator.SetTrigger(Tags.STOP_TRIGGER);
            }
        }
    }

    void ActivateDamagePoint()
    {
        damagePoint.SetActive(true);
    }

    void DeactivateDamagePoint()
    {
        damagePoint.SetActive(false);
    }
}
