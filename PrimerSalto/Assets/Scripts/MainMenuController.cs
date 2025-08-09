using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;  // si us�s un panel separado
    public GameObject mainMenuUI;     // grupo que contiene t�tulo, bot�n, company text
    public ScoreManager scoreManager;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        mainMenuUI.SetActive(false);   // ocultar todo lo del men�
        Time.timeScale = 1f;
    }
}
