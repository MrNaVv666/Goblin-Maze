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

    private void Start()
    {
        GameplayController.instance.DisplayHealth(health);
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        GameplayController.instance.DisplayHealth(health);

        if (health == 0)
        {
            playerController.enabled = false;
            animator.Play(Tags.DEAD_ANIMATION);
            GameplayController.instance.isPlayerAlive = false;
            GameplayController.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.COIN_TAG)
        {
            other.gameObject.SetActive(false);
            GameplayController.instance.CoinGet();
            SoundManager.instance.PlayCoinSound();
        }
    }
}
