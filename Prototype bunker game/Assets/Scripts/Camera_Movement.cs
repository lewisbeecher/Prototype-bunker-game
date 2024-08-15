using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float leftLimit, rightLimit, topLimit, bottomLimit;
    public float moveSpeed;

    Vector2 moveDirection;
    Rigidbody2D rb2D;

    [Header("Camera zooms")]
    public Camera cam;
    public bool IsZoomed;

    // Explain all of this code :3
    void Start()
    {
        IsZoomed = false;

        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        Mathf.Clamp(transform.position.y, bottomLimit, topLimit));

        // Zooms camera in
        if(Input.GetKeyDown(KeyCode.E) && !IsZoomed){
            IsZoomed = true;
            cam.orthographicSize = 8;
            //Debug.Log("zoom in");
        } else{ // Zooms camera out
            if(Input.GetKeyDown(KeyCode.E) && IsZoomed){
                IsZoomed = false;
                cam.orthographicSize = 15;
                //Debug.Log("zoom out");
            }
        }

    }

    void Move()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        rb2D.MovePosition(rb2D.position + moveDirection * moveSpeed * Time.deltaTime);
    }
    
}
