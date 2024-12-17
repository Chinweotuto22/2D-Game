using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public  Text scoreText;
    public TextMeshProUGUI TotalScore; 
    private int scoreValue = 0; // The actual score value, no need to be static

    void Awake()
    {
        // Ensure there's only one instance of ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Make this object persistent across scenes (optional)
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        scoreText = FindAnyObjectByType<Text>();
        // Initialize the score display
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        scoreValue += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + scoreValue.ToString();
        }
        if (TotalScore != null)
        {
            TotalScore.text = "TotalScore = " + scoreValue.ToString();
        }

    }

    public int GetScore()
    {
        return scoreValue;
    }
}


