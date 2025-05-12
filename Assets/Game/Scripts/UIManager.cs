using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public int score;
    public Text scoreText;

    public void UpdateLives(int currentLives)
    {
       livesImageDisplay.sprite = lives[currentLives];
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
