using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject scoreUI; // Panel que contiene scoreText y highScoreText en juego

    [Header("Score Texts")]
    public TMP_Text scoreText;             // Puntaje actual en juego
    public TMP_Text highScoreText;         // Highscore visible en juego
    public TMP_Text highScoreMenuText;     // Highscore en menú principal
    public TMP_Text gameOverHighScoreText; // Highscore en pantalla de game over
    public TMP_Text finalScoreText;        // Puntaje final en game over

    private bool isPaused = false;
    private bool isGameOver = false;

    void Awake()
    {
        ShowMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver && !mainMenuUI.activeSelf)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        scoreUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = false;
        isGameOver = false;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreMenuText != null)
            highScoreMenuText.text = "High Score: " + highScore;
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        scoreUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        isGameOver = false;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowGameOver(int finalScore, int highScore)
    {
        gameOverUI.SetActive(true);
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + finalScore;
        if (gameOverHighScoreText != null)
            gameOverHighScoreText.text = "High Score: " + highScore;
        Time.timeScale = 0f;
        isPaused = false;
        isGameOver = true;
        scoreUI.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Cambiar si el nombre es distinto
    }

    public void UpdateScore(int currentScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }
}
