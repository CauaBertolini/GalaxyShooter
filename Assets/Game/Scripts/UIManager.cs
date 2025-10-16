using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public int score;
    public Text scoreText;
    public Text timerText;

    public GameObject titleScreen;
    public GameManager gameManager;

    public void UpdateLives(int currentLives)
    {
       livesImageDisplay.sprite = lives[currentLives];
       if (currentLives < 0) {
            gameManager.EndTheGame();
       }
    }

    public void ShowTitleScreen() {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen() {
        titleScreen.SetActive(false);
    }

    public void UpdateTimer(double time) {
         timerText.text = $"TIMER: {time:F4}";
    }

    public void UpdateScore()
    {
        if (Time.time < 302) {
            score += 5;
            scoreText.text = "SCORE: " + score;
        } else {
            score += 10;
            scoreText.text = "SCORE: " + score;
        }

    }

    public void PenalizeScore() 
    {
        score -= 20;
        scoreText.text = "SCORE: " + score;
    }

    public void ResetScore() 
    {
        score = 0;
        timerText.text = "";
        scoreText.text = "";
    }
}
