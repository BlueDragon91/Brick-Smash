using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float lives = 3;
    public float scores = 0;
    public int level = 1;
    public Ball ball { get; private set; }
    public MouseMove paddle { get; private set; }
    public BrickCollision[] Bricks { get; private set; }

    //private GameOver GameO;

    
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    

    public void NewGame()
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
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<MouseMove>();
        this.Bricks = FindObjectsOfType<BrickCollision>();
    }

    public void Hit(BrickCollision Brick)
    {
        this.scores += Brick.Points;
        //Score.text = this.scores.ToString();

        if (cleared())
        {
            NextLevel(this.level + 1);
        }
    }

    public bool cleared()
    {
        for (int i = 0; i < Bricks.Length; i++)
        {
            if(this.Bricks[i].gameObject.activeInHierarchy && !this.Bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!!!!");
        //GameO.level = this.level;
        SceneManager.LoadScene("GameOver");
     
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
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
            GameOver();
        }
    }
}
