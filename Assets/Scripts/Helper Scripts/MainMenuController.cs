using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
