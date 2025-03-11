using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator2;
    void Start()
    {
        animator2 = GetComponent<Animator>();   
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == Tags.PLAYER_TAG)
        {
            animator2.Play("DoorOpen");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == Tags.PLAYER_TAG)
        {
            animator2.Play("DoorClose");
        }
    }
}
