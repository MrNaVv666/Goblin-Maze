using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator animator;

    public void PlayGame()
    {
        animator.Play("SlideIN");
    }

    public void Back()
    {
        animator.Play("SlideOUT");
    }
}
