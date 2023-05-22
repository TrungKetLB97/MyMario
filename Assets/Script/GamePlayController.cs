using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;
    public void PauseGameButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetButton()
    {
        gameOverPanel.SetActive(false);
        Application.LoadLevel("level1");
    }
    public void OutButton()
    {
        Application.LoadLevel("menu");
    }
    public void PlaneDiedShowPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
