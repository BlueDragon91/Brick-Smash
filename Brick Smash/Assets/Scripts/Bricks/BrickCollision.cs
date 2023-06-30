using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    private SpriteRenderer render;
    private int hitCount;
    private int maxHit;
    public Sprite[] sprites;
    private GameObject brick;
    public int Points = 100;
    public bool unbreakable;

   
    void Awake()
    {
        this.render = GetComponent<SpriteRenderer>();
        brick = this.gameObject;
    }

    private void Start()
    {
        
    }

    // bricks disappear when the ball collides with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(!unbreakable && collision.gameObject.tag == "Ball")
        {
            hitBrick();
        }
        
    }

    private void hitBrick()
    {
        hitCount++;
        maxHit = sprites.Length + 1;
        if(hitCount >= maxHit)
        {
            brick.SetActive(false);
        }
        else
        {
            changeSprites();
        }

        FindAnyObjectByType<GameManager>().Hit(this);
    }

    private void changeSprites()
    {
        int sIndex = hitCount - 1;

        if(sprites[sIndex] != null)
        {
            render.sprite = sprites[sIndex];
        }
        else
        {
            Debug.Log("Sprite not found");
        }
    }
}
