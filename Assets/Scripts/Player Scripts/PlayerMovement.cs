using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int movementSpeed;

    public Rigidbody2D rb;

    public string direction = "north";

    public Camera sceneCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        setDirection();
        mouseDirection();
    }

    void movement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hor * movementSpeed, ver * movementSpeed);
    }

    void setDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = "north";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = "south";
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = "west";
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = "east";
        }
    }

    void mouseDirection()
    {
        Vector2 mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        float sideA = transform.position.x - mousePos.x;
        float sideB = transform.position.y - mousePos.y;

        float zAngle = Mathf.Atan2(sideB, sideA) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0f, 0f, zAngle);
    }
}
