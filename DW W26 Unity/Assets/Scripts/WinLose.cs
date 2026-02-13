using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Win()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("WinScene");
    }

    public void Lose()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoseScene");
    }
}
