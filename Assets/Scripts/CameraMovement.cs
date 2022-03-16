using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float dragSpeed = 50;
    float scrollSpeed = 2;
    private Vector3 dragOrigin;
 
 
    void Update()
    {
        HandleDrag();
        HandleScroll();
    }

    void HandleDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(1)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * -dragSpeed, pos.y * dragSpeed, 0);
 
        transform.Translate(move, Space.World);

        dragOrigin = Input.mousePosition;
    }

    void HandleScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(new Vector3(0, 0, scroll * scrollSpeed));

            if (transform.position.z < 5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 5);
            }
            else if (transform.position.z > 25)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 25);
            }
        }
    }
}
