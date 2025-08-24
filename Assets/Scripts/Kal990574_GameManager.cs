using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kal990574_GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearText;
    public GameObject restartButton;

    void Start()
    {
        Time.timeScale = 1f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (gameClearText != null)
            gameClearText.SetActive(false);
        if (restartButton != null)
            restartButton.SetActive(false);
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        Time.timeScale = 0.0001f; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameClear()
{
    Time.timeScale = 0.0001f;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    if (gameClearText != null)
        gameClearText.SetActive(true);

    if (restartButton != null)
        restartButton.SetActive(true);
}
}
