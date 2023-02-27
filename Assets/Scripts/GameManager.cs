using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;
    public int oxygen;
    public TextMeshProUGUI oxygenText;
    public bool isRoundActive = true;
    public TextMeshProUGUI timerText;
    private int secondsToEnd;
    public int timeOfRound = 60;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = "Health: " + health + "%";
        oxygen = 100;
        oxygenText.text = "O2: " + oxygen + "%";
        secondsToEnd = timeOfRound;
        StartCoroutine(Timer());
    }

    public void UpdateTimer()
    {
        timerText.text = $"Time: {secondsToEnd}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Timer()
    {
        while (isRoundActive)
        {
            UpdateTimer();

            if (secondsToEnd == 0)
            {
                isRoundActive = false;
            }

            yield return new WaitForSeconds(1);
            secondsToEnd--;
        }
    }
}