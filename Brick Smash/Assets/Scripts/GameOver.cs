using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

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
    
}
