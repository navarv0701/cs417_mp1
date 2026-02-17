using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }
}