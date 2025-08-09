using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;

    private float score = 0f;

    void Update()
    {
        // La puntuación será la posición X del jugador (distancia recorrida)
        score = player.position.x;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}
