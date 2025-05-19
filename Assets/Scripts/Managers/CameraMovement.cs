using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] float sensitivity = 10f;
    [SerializeField] float maxYAngle = 80f;
    [SerializeField] float maxXAngle = 10f;
    private Vector2 currentRotation;

    [Header("Camera Zoom")]
    [SerializeField] private float zoomFOV;
    [SerializeField] private float normalFOV;
    [SerializeField] float zoomSpeed;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -maxYAngle, maxYAngle);
        //currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
       currentRotation.y = Mathf.Clamp(currentRotation.y, -maxXAngle, maxXAngle);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

        float targetFOV;

        if (Input.GetMouseButton(1))
        {
            targetFOV = zoomFOV;
        }
        else
        {
            targetFOV = normalFOV;
        }

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }
}
