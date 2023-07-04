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

    // Always runs first when the script is loaded
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    
    // creates the new game and launches the level 1 with score = 0 and life = 3
    public void NewGame()
    {
        this.lives = 3;
        this.scores = 0;

        NextLevel(1);
    }

    // loads the next level 
    private void NextLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("level" + level);
    }

    // keep the following object when the next level is loaded
    private void OnLevelLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<MouseMove>();
        this.Bricks = FindObjectsOfType<BrickCollision>();
    }

    // increment the scores on every brick break and loads the next level when all the breakable bricks are gone
    public void Hit(BrickCollision Brick)
    {
        this.scores += Brick.Points;
        //Score.text = this.scores.ToString();

        if (cleared())
        {
            NextLevel(this.level + 1);
        }
    }

    // checks if all the breakable bricks are cleared
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


    // resets the position of ball and paddle when the ball collides with the dead zone
    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    // when all 3 lives are used this function is called and the GameOver scene is loaded
    private void GameOver()
    {
        Debug.Log("GAME OVER!!!!");
        //GameO.level = this.level;
        SceneManager.LoadScene("GameOver");
     
    }


    /** This function handles the ball collision with dead zone scenerio, 
        if the collision happens when the lives are more than 1 then the resetlvel method is called
        else GameOver method is called
     */
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
