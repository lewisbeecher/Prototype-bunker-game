using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float leftLimit, rightLimit, topLimit, bottomLimit;
    public float moveSpeed;

    Vector2 moveDirection;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        transform.position = new Vector2
        {
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
            Mathf.Clamp(transform.position.y bottomLimit, topLimit)
        }
    }
}
