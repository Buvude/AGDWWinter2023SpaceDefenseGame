using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject pauseScreen;
    public bool isGamePaused;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = "Health: " + health + "%";
        oxygen = 100;
        oxygenText.text = "O2: " + oxygen + "%";
        secondsToEnd = timeOfRound;
        StartCoroutine(Timer());
        isGamePaused = false;
    }

    public void StartGame()
    {
        isGameActive = true;
    }

    public void UpdateTimer()
    {
        timerText.text = $"Time: {secondsToEnd}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape is pressed.");
        }
    }

    void PauseGame()
    {
        // can't pause in title and game over screen
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeInHierarchy && isGameActive)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            isGamePaused = true;
            Debug.Log("Game is paused.");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            isGamePaused = false;
            Debug.Log("Game will resume.");
        }
    }

    /*public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    */
    public void GameOver()
    {
        isGameActive = false;
    }

    IEnumerator Timer()
    {
        if (!isGamePaused)
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
}