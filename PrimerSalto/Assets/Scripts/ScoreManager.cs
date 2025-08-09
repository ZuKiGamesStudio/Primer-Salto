using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    private int highScore;

    private UIManager uiManager;

    private int score = 0;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        int currentScore = Mathf.FloorToInt(player.position.x);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (uiManager != null)
            uiManager.UpdateScore(currentScore);
    }
}