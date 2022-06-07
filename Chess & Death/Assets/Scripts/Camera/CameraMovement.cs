using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // WASD MOVEMENT VARIABLES
    public float cameraMoveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    // DRAG MOVEMENT VARIABLES
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;
    private bool drag = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // WASD MOVEMENT
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * cameraMoveSpeed;
    }

    // MIDDLE MOUSE BUTTOM DRAG MOVEMENT
    private void LateUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference;
        }

        // RESET CAMERA TO START POSITION
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.position = ResetCamera;
        }
    }
}
