using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStart() => Load("StartScene");
    public void LoadGame() => Load("Dual Monitor Scene");
    public void LoadWin() => Load("WinScene");
    public void LoadLose() => Load("LoseScene");

    public void ReloadCurrent()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Load(string sceneName)
    {
        Time.timeScale = 1f; // 
        SceneManager.LoadScene(sceneName);
    }
}
