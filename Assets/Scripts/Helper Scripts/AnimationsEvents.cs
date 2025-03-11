using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    public GameObject player, playButton;

    void DeactivateGameObjects()
    {
        player.SetActive(false);
        playButton.SetActive(false);    
    }

    void ActivateGameObjects()
    {
        player.SetActive(true);
        playButton.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == Tags.PLAYER_TAG)
        {

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == Tags.PLAYER_TAG)
        {

        }
    }
}
