using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePaddle();
    }

    // Paddle Movement
    private void movePaddle()
    {
        float hrz = Input.GetAxisRaw("Horizontal");
        //float ver = Input.GetAxis("Vertical");

        body.velocity = new Vector2(Mathf.Clamp(hrz * speed, -15, 15), transform.position.y);
    }

    
}
