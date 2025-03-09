using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{
    [HideInInspector] public bool isPlayerAlive;
    public static GameplayController instance;
    public float timerTime = 0;

    private int coinScore;
    
    private TextMeshProUGUI coinText, healthText, timerText;


    void Awake()
    {
        MakeInstance();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        print(coinText);

        coinText.text = "Coins: " + coinScore;
    }

    void Start()
    {
        isPlayerAlive = true;
    }

    void Update()
    {
        Countdown();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance !=null)
        {
            Destroy(gameObject);
        }
    }

    public void CoinGet()
    {
        coinScore++;
        coinText.text = "Coins: " + coinScore;
    }

    public void DisplayHealth(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void Countdown()
    {
        timerTime -= Time.deltaTime;
        timerText.text = "Time: " + timerTime.ToString("F0");
    }
}
