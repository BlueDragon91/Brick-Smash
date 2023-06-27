using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    //#region Variable Declaration
    public Rigidbody2D rigidbody2;
    [SerializeField] private float speed; // Rotation Speed
    [SerializeField] private float min;
    [SerializeField] private float max;

    //#region Update
    void Update()
    {
        
        // Paddle moves in the x-axis with the mouse pointer
        Vector2 posX = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(posX.x, transform.position.y);

        // calling rotation function at every frame
        rotation1();

        
    }
    // #endregion

    // function for paddle rotation using A and D key for left and right rotation respectively
    private void rotation1()
    {

        if (Input.GetKey(KeyCode.A) && (transform.rotation.eulerAngles.z < 15 || transform.rotation.eulerAngles.z > 195 ))
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        else if (Input.GetKey(KeyCode.D) && (transform.rotation.eulerAngles.z > min || transform.rotation.eulerAngles.z < max)) // not clamping
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

    }
}
