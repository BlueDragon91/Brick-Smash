using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    //#region Variable Declaration
    public Rigidbody2D body { get; private set; }
    //[SerializeField] private float speed; // Rotation Speed
    
    private float mouseX;
    float maxBounceAngle = 70f;

    //[SerializeField] private AudioSource BallCollisionSound;

    private void Start()
    {
        
        body = this.GetComponent<Rigidbody2D>();
    }

    //#region Update
    void Update()
    {
        
        // Paddle moves in the x-axis with the mouse pointer
        mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseX = Mathf.Clamp(mouseX, -15, 15);
        transform.position = new Vector2(mouseX, transform.position.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Creates the ball's bounce reflection, which is going to be reflected at "maxBounceAngle" at max
    {
        //BallCollisionSound.Play(); // plays the sound when the ball collides with the paddle

        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.body.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.body.velocity = rotation * Vector2.up * ball.body.velocity.magnitude;
        }
    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, transform.position.y);
        this.body.velocity = Vector2.zero;
    }

}
