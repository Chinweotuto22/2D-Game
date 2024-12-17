using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    public Text finalScoreText;

    private void Awake()
    {
        gameOverScreen.SetActive(false);     
    }

    private void Update()
    {
       
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);

        if (gameOverScreen != null)
        {
            Time.timeScale = 0;
        }

        SoundManager.instance.PlaySound(gameOverSound);

        finalScoreText.text = "Score: " + ScoreManager.instance.GetScore().ToString();
        
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
