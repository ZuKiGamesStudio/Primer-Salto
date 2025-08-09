using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public GameObject gameOverUI;

    public void ShowGameOver(int finalScore, int highScore)
    {
        gameOverUI.SetActive(true);
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Temporal para que la escena recargue bien
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
