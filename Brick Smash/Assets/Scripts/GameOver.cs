using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool GamePaused;
    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                resumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ReplayLevel()
    {
        FindAnyObjectByType<GameManager>().NewGame();
        //SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel", 0));
        Debug.Log("Its Workingggg!!!!");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void resumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    private void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
