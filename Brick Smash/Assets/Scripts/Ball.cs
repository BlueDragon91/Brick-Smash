using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D body { get; private set; }
    [SerializeField] private float speed = 500f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        // pressing Space Bar will launch the Ball towards the Paddle
        if (Input.GetKeyDown(KeyCode.Space))
            ballLaunch();
    }

    private void ballLaunch()
    {
        Vector2 forceDir = Vector2.zero;
        //forceDir.x = Mathf.Clamp(forceDir.x, -1f, 1f);
        forceDir.y = -1f;

        body.AddForce(forceDir.normalized * speed);
    }

    public void ResetBall()
    {
        // sets the ball at center position before invoke method runs
        this.transform.position = Vector2.zero;
        this.body.velocity = Vector2.zero;
        
        // run the ballLaunch method after 1 second delay
        Invoke(nameof(ballLaunch), 1f); 
    }
}
