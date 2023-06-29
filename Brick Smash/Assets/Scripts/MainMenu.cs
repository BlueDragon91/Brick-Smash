using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("_main");
    }

    public void ExitButton()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("<b>Khel Samapti ki Ghoshana</b>");
    }
}
