using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    public int health = 100;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
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
            playerController.enabled = false;
            animator.Play(Tags.DEAD_ANIMATION);
        }
    }
}
