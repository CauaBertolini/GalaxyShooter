using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public int score;
    public Text scoreText;

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

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;

    }

    public void PenalizeScore() 
    {
        score -= 20;
        scoreText.text = "SCORE: " + score;
    }

    public void ResetScore() 
    {
        score = 0;
        scoreText.text = "";
    }
}
