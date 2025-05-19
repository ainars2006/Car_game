using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public float maxZoom = 300f;
    public float minZoom = 150f;
    public float zoomSpeed = 5f;
    public float moveSpeed = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Make sure the camera is set to Orthographic
        if (!cam.orthographic)
        {
            Debug.LogWarning("Camera is not set to Orthographic. Zoom won't work correctly.");
        }
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            cam.orthographicSize -= scroll * zoomSpeed * 100f * Time.deltaTime;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
