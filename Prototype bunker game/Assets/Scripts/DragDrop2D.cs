using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    Rigidbody2D rb;
    public string destinationTag = "DropArea";

    void Awake()
    {
        // Getting the collider from the prefab
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        // called whenever left mb is down
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        // takes the prefab pos and moves it to the mouse position relative to world pos
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;

        // Shooting out ray from mouse position to check for colliders
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                //Debug.Log(hitInfo.transform.name);
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);

                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            else{
                rb.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    Vector3 MouseWorldPosition()
    {
        // Getting position of the mouse on the screen
        var mouseScreenPos = Input.mousePosition;
        // Converting the mouse position on the screen to a position within in the world
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        // returning the position
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    void Update(){
        transform.eulerAngles = new Vector3(0,0,0);
    }
}
