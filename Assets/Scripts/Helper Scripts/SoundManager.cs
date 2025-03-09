using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource coinSound;

    void Awake()
    {
        MakeInstance();
    }

    void Update()
    {
        
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound()
    {
        coinSound.Play();
    }
}
