using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float lives = 3;
    public float scores = 0;
    public float level = 1;
    public Ball ball { get; private set; }
    public MouseMove paddle { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.lives = 3;
        this.scores = 0;

        NextLevel(1);
    }

    private void NextLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        this.ball = FindAnyObjectByType<Ball>();
        this.paddle = FindAnyObjectByType<MouseMove>();
    }

    public void Hit(BrickCollision Brick)
    {
        this.scores += Brick.Points;
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!!!!");
    }

    public void Miss()
    {
        this.lives--;

        if(lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
}
