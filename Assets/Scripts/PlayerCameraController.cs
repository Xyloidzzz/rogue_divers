/**************************************************************************
 *
 * Name: PlayerCameraController.cs
 * Author: Alfredo Peña
 * Rogue Divers Concept Prototype
 * Purpose: Add basic controls to the camera hovering above player.
 * Created: 10/28/2024
 * Last Modified: 12/17/2024
 * 
 **************************************************************************/

using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    private const float YMin = -80.0f;
    private const float YMax = 80.0f;

    public Transform lookAt;

    public float distance = 5.0f;
    public float sensitivity = 100.0f;
    
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;
    
    public void LateUpdate()
    {
        _currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        _currentY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _currentY = Mathf.Clamp(_currentY, YMin, YMax); // Limit camera vertical rotation.

        Vector3 direction = new (0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        transform.position = lookAt.position + rotation * direction;

        transform.LookAt(lookAt.position);
    }
}