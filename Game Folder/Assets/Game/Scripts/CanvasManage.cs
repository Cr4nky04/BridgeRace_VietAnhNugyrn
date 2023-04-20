using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManage : MonoBehaviour
{
    public static bool GameIsPaued = false;

    public void Pause()
    {
        GameIsPaued = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GameIsPaued = false;
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
