using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float sensitivity = 10f;
    [SerializeField] float maxYAngle = 80f;
    [SerializeField] float maxXAngle = 10f;
    private Vector2 currentRotation;

 
    private void Update()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -maxYAngle, maxYAngle);
        //currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
       currentRotation.y = Mathf.Clamp(currentRotation.y, -maxXAngle, maxXAngle);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        
    }
}
