using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource BGSound;
    public void StartGame()
    {
        BGSound.Play();
        SceneManager.LoadScene("_main");
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
    }
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("<b>Khel Samapti ki Ghoshana</b>");
    }
}
