/**************************************************************************
 *
 * Name: PlayerMovement.cs
 * Author: Alfredo Peña
 * Rogue Divers Concept Prototype
 * Purpose: Add basic controls to the player character.
 * Created: 10/28/2024
 * Last Modified: 10/28/2024
 * 
 **************************************************************************/

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10.0f;

    public new Transform camera;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = camera.transform.right * horizontal + camera.transform.forward * vertical;
        movement.y = 0f;
        
        controller.Move(movement);

        if (movement.magnitude == 0f) return;
        transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * camera.GetComponent<PlayerCameraController>().sensitivity * Time.deltaTime));
            
        Quaternion cameraRotation = camera.rotation;
        cameraRotation.x = 0f;
        cameraRotation.z = 0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, 0.1f);
    }
}