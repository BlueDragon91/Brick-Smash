using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    private SpriteRenderer render;
    public int hitCount;
    private int maxHit;
    public Sprite[] sprites;
    private GameObject brick;
    private bool breakable = true;

    // Start is called before the first frame update
    void Awake()
    {
        this.render = GetComponent<SpriteRenderer>();
        brick = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    // bricks disappear when the ball collides with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(breakable)
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
            Destroy(brick);
        }
        else
        {
            changeSprites();
        }
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
