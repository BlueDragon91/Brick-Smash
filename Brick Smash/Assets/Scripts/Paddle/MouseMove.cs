using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    //#region Variable Declaration
    public Rigidbody2D body { get; private set; }
    [SerializeField] private float speed; // Rotation Speed
    [SerializeField] private float min;
    [SerializeField] private float max;
    private float mouseX;
    float maxBounceAngle = 70f;

    private void Start()
    {
        min = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, 0)).x;
        max = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, 1)).x;

        body = this.GetComponent<Rigidbody2D>();
    }

    //#region Update
    void Update()
    {
        
        // Paddle moves in the x-axis with the mouse pointer
        mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseX = Mathf.Clamp(mouseX, -15, 15);
        transform.position = new Vector2(mouseX, transform.position.y);

        // calling rotation function at every frame
        //rotation1();

        
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Creates the ball's bounce reflection, which is going to be reflected at maxBounceAngle
    {
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

    // #endregion

    // function for paddle rotation using A and D key for left and right rotation respectively
    //private void rotation1()
    //{

    //    if (Input.GetKey(KeyCode.A) && (transform.rotation.eulerAngles.z < 15 || transform.rotation.eulerAngles.z > 195 ))
    //        transform.Rotate(Vector3.forward * speed * Time.deltaTime);

    //    else if (Input.GetKey(KeyCode.D) && (transform.rotation.eulerAngles.z > min || transform.rotation.eulerAngles.z < max)) // not clamped
    //        transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

    //}
}
